using MediatR;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Repositories;

namespace TaskGarden.Application.Features.Invitation.Commands.DeclineInvite;

public record DeclineInviteCommand(string Token) : IRequest<bool>;

public class DeclineInviteCommandHandler(IInvitationRepository invitationRepository)
    : IRequestHandler<DeclineInviteCommand, bool>
{
    public async Task<bool> Handle(DeclineInviteCommand request, CancellationToken cancellationToken)
    {
        var invitation = await invitationRepository.GetByTokenAsync(request.Token);
        if (invitation is null || invitation.Status != InvitationStatus.Pending)
            return false;

        await DeclineInvitationAsync(invitation);
        return true;
    }

    private async Task DeclineInvitationAsync(Domain.Entities.Invitation invitation)
    {
        invitation.Status = InvitationStatus.Declined;
        invitation.ExpiresAt = invitation.UpdatedAt = DateTime.UtcNow;
        await invitationRepository.UpdateAsync(invitation);
    }
}