using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Projections;
using TaskGarden.Infrastructure.Repositories;
using System.Security.Claims;

namespace TaskGarden.Application.Features.Invitation.Commands.InviteUser;

public record InviteUserCommand : IRequest<bool>
{
    public string InvitedUserEmail { get; init; } = default!;
    public int TaskListId { get; init; }
}

public class InviteUserCommandHandler : IRequestHandler<InviteUserCommand, bool>
{
    private readonly IInvitationRepository _invitationRepository;
    private readonly IEmailService _emailService;
    private readonly IUserContextService _userContextService;
    private readonly ITaskListRepository _taskListRepository;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public InviteUserCommandHandler(
        IInvitationRepository invitationRepository,
        IEmailService emailService,
        IUserContextService userContextService,
        ITaskListRepository taskListRepository,
        ITokenService tokenService,
        IUserService userService
    )
    {
        _invitationRepository = invitationRepository;
        _emailService = emailService;
        _userContextService = userContextService;
        _taskListRepository = taskListRepository;
        _tokenService = tokenService;
        _userService = userService;
    }

    public async Task<bool> Handle(InviteUserCommand request, CancellationToken cancellationToken)
    {
        if (await _invitationRepository.InvitationExistsAsync(request.InvitedUserEmail, request.TaskListId))
        {
            throw new ConflictException("An invitation already exists for this user.");
        }

        var inviterUserId = _userContextService.GetAuthenticatedUserId();
        var inviter = await _userService.GetUserByIdAsync(inviterUserId);

        if (inviter == null)
            throw new NotFoundException("Inviter not found");

        var taskList = await _taskListRepository.GetDetailsByIdAsync(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found");

        var invitation = new Domain.Entities.Invitation
        {
            TaskListId = request.TaskListId,
            InvitedUserEmail = request.InvitedUserEmail,
            InviterUserId = inviterUserId,
            Token = _tokenService.GenerateInviteToken(inviter, taskList),
            Status = InvitationStatus.Pending,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        await _invitationRepository.AddAsync(invitation);

        var inviteUrl = $"https://localhost:5173/invite/{invitation.Token}";
        var placeholders = new Dictionary<string, string>
        {
            { "Recipient's Email", request.InvitedUserEmail },
            { "Invite Link", inviteUrl }
        };

        await _emailService.SendEmailAsync("Task Garden", request.InvitedUserEmail, "You’ve been invited!",
            "InviteUserTemplate", placeholders);

        return true;
    }
}