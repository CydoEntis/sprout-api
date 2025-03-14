using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Repositories;

namespace TaskGarden.Application.Features.Invitation.Commands.AcceptInvite;

public record AcceptInviteCommand(string Token) : IRequest<bool>;

public class AcceptInviteCommandHandler(
    IInvitationRepository invitationRepository,
    IUserContextService userContextService,
    ITaskListMemberRepository taskListMemberRepository)
    : IRequestHandler<AcceptInviteCommand, bool>
{
    public async Task<bool> Handle(AcceptInviteCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        var invitation = await invitationRepository.GetByTokenAsync(request.Token);

        if (invitation == null || invitation.Status != InvitationStatus.Pending ||
            invitation.ExpiresAt < DateTime.UtcNow)
            throw new NotFoundException("Invite has expired, or has already been accepted");

        var taskListId = invitation.TaskListId;

        var existingMember = await taskListMemberRepository.GetByUserAndTaskListAsync(userId, taskListId);
        if (existingMember != null)
            throw new ConflictException("User is already part of this task list");

        invitation.Status = InvitationStatus.Accepted;
        await invitationRepository.UpdateAsync(invitation);

        var newMember = new TaskListMember
        {
            UserId = userId,
            TaskListId = taskListId,
            Role = TaskListRole.Viewer
        };
        await taskListMemberRepository.AddAsync(newMember);

        return true;
    }
}