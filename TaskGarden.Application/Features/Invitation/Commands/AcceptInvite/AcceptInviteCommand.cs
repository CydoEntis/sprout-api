using MediatR;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Repositories;

namespace TaskGarden.Application.Features.Invitation.Commands.AcceptInvite;

public record AcceptInvitationCommand(string Token) : IRequest<bool>;

public class AcceptInvitationCommandHandler(
    IInvitationRepository invitationRepository,
    IUserContextService userContextService)
    : IRequestHandler<AcceptInvitationCommand, bool>
{
    public async Task<bool> Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        var invitation = await invitationRepository.GetByTokenAsync(request.Token);
        if (invitation == null || invitation.Status != InvitationStatus.Pending ||
            invitation.ExpiresAt < DateTime.UtcNow)
            return false;

        invitation.Status = InvitationStatus.Accepted;
        await invitationRepository.UpdateAsync(invitation);

        // Additional logic for assigning the user to the task list can go here.
        // This may include checking if the user is already in the task list and assigning the correct role.

        return true;
    }
}