using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Projections;
using TaskGarden.Infrastructure.Repositories;

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
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IUserContextService _userContextService;
    private readonly string _jwtSecretKey;
    private readonly UserManager<AppUser> _userManager;
    private readonly ITaskListRepository _taskListRepository;

    public InviteUserCommandHandler(
        IInvitationRepository invitationRepository,
        IEmailService emailService,
        IEmailTemplateService emailTemplateService,
        IUserContextService userContextService,
        IConfiguration configuration,
        UserManager<AppUser> userManager,
        ITaskListRepository taskListRepository
    )
    {
        _invitationRepository = invitationRepository;
        _emailService = emailService;
        _emailTemplateService = emailTemplateService;
        _userContextService = userContextService;
        _jwtSecretKey = configuration["JwtSecret"];
        _userManager = userManager;
        _taskListRepository = taskListRepository;
    }

    public async Task<bool> Handle(InviteUserCommand request, CancellationToken cancellationToken)
    {
        if (await _invitationRepository.InvitationExistsAsync(request.InvitedUserEmail, request.TaskListId))
        {
            throw new ConflictException("An invitation already exists for this user.");
        }

        var inviterUserId = _userContextService.GetUserId();
        var inviter = await _userManager.FindByIdAsync(inviterUserId!);

        if (inviter == null)
            throw new NotFoundException("Inviter not found");

        var taskList = await _taskListRepository.GetDetailsByIdAsync(request.TaskListId);
        if (inviter == null)
            throw new NotFoundException("Inviter not found");

        var invitation = new Domain.Entities.Invitation
        {
            TaskListId = request.TaskListId,
            InvitedUserEmail = request.InvitedUserEmail,
            InviterUserId = inviterUserId,
            Token = GenerateInviteToken(inviter, taskList),
            Status = InvitationStatus.Pending,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        await _invitationRepository.AddAsync(invitation);
        var inviteUrl = $"https://localhost:5173/invite/{invitation.Token}";

        var placeholders = new Dictionary<string, string>
        {
            { "Recipient's Email", request.InvitedUserEmail },
            { "Invite Link", inviteUrl },
        };

        var emailBody = _emailTemplateService.GetEmailTemplate("InviteUserTemplate", placeholders);
        await _emailService.SendEmailAsync("Task Garden", request.InvitedUserEmail, "You’ve been invited!",
            emailBody);

        return true;
    }

    private string GenerateInviteToken(AppUser inviter, TaskListPreview taskList)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<System.Security.Claims.Claim>
        {
            new System.Security.Claims.Claim("inviter", inviter.FirstName + " " + inviter.LastName),
            new System.Security.Claims.Claim("inviter", inviter.Email),
            new System.Security.Claims.Claim("taskListName", taskList.Name),
            new System.Security.Claims.Claim("category", taskList.CategoryName),
            new System.Security.Claims.Claim("inviteDate", DateTime.UtcNow.ToString("MM/dd/yyyy"))
        };

        foreach (var member in taskList.Members)
        {
            claims.Add(new System.Security.Claims.Claim("memberName",
                member.Name));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}