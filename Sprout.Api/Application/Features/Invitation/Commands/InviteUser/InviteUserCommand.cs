﻿using MediatR;
using Sprout.Application.Common.Exceptions;
using Sprout.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Extensions;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Projections;
using Sprout.Api.Domain.Entities;
using Sprout.Api.Domain.Enums;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Api.Infrastructure.Services.Interfaces;
using Sprout.Application.Common.Constants;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Features.Invitation.Commands.InviteUser;

public record InviteUserCommand : IRequest<bool>
{
    public List<string> InvitedUserEmails { get; init; } = new();
    public int TasklistId { get; init; }
    public TaskListRole Role { get; init; }
}

public class InviteUserCommandHandler : AuthRequiredHandler, IRequestHandler<InviteUserCommand, bool>
{
    private readonly AppDbContext _context;
    private readonly IEmailService _emailService;
    private readonly ITokenService _tokenService;

    public InviteUserCommandHandler(
        IHttpContextAccessor httpContextAccessor,
        AppDbContext context,
        IEmailService emailService,
        ITokenService tokenService,
        IConfiguration configuration) : base(httpContextAccessor)
    {
        _context = context;
        _emailService = emailService;
        _tokenService = tokenService;
    }

    public async Task<bool> Handle(InviteUserCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();
        var user = await GetUserByIdAsync(userId);

        if (user == null)
            throw new NotFoundException("User not found.");

        var taskList = await GetTaskListDetailsById(request.TasklistId);
        if (taskList == null)
            throw new NotFoundException("Task list not found");

        foreach (var email in request.InvitedUserEmails)
        {
            var existingInvite = await _context.Invitations
                .Where(i => i.InvitedUserEmail == email && i.TasklistId == request.TasklistId &&
                            i.Status == InvitationStatus.Pending)
                .FirstOrDefaultAsync();

            if (existingInvite != null)
            {
                existingInvite.Status = InvitationStatus.Cancelled;
                _context.Invitations.Update(existingInvite);
                await _context.SaveChangesAsync();
            }

            if (await _context.TaskListMembers.IsMemberAsync(email, request.TasklistId))
                continue;

            var invitation = await CreateInviteAsync(taskList, email, user, request.Role);
            if (invitation == null)
                throw new ResourceCreationException($"Failed to create invite for {email}.");

            await SendInviteEmail(invitation, email);
        }

        return true;
    }

    private async Task<AppUser?> GetUserByIdAsync(string userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    private async Task<TaskListOverview?> GetTaskListDetailsById(int id)
    {
        return await _context.TaskLists
            .Where(q => q.Id == id)
            .Select(tl => new TaskListOverview()
            {
                Id = tl.Id,
                Name = tl.Name,
                Members = tl.TaskListMembers
                    .Select(tla => new Member
                    {
                        UserId = tla.User.Id,
                        Name = tla.User.FirstName + " " + tla.User.LastName,
                    })
                    .ToList(),
            })
            .FirstOrDefaultAsync();
    }

    private async Task<Domain.Entities.Invitation> CreateInviteAsync(TaskListOverview taskList, string recipientsEmail,
        AppUser inviter, TaskListRole role)
    {
        var invitation = new Domain.Entities.Invitation
        {
            TasklistId = taskList.Id,
            InvitedUserEmail = recipientsEmail,
            InviterUserId = inviter.Id,
            Token = _tokenService.GenerateInviteToken(inviter, taskList.Id, taskList.Name, taskList.Members, recipientsEmail),
            Status = InvitationStatus.Pending,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            Role = role
        };

        await _context.Invitations.AddAsync(invitation);
        await _context.SaveChangesAsync();
        return invitation;
    }

    private async Task SendInviteEmail(Domain.Entities.Invitation invite, string recipientsEmail)
    {
        var inviteUrl = $"https://localhost:5173/invite/{invite.Token}";
        var placeholders = new Dictionary<string, string>
        {
            { "Recipient's Email", recipientsEmail },
            { "Invite Link", inviteUrl }
        };

        await _emailService.SendEmailAsync("Task Garden", recipientsEmail, "You’ve been invited!",
            "InviteUserTemplate", placeholders);
    }
}