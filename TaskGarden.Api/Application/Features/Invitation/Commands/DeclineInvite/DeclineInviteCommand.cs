using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Invitation.Commands.DeclineInvite;

public record DeclineInviteCommand(string Token) : IRequest<bool>;

public class DeclineInviteCommandHandler
    : AuthRequiredHandler, IRequestHandler<DeclineInviteCommand, bool>
{
    private readonly AppDbContext _context;

    public DeclineInviteCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
        httpContextAccessor)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeclineInviteCommand request, CancellationToken cancellationToken)
    {
        var invitation = await _context.Invitations.GetByInviteToken(request.Token);
        if (invitation is null || invitation.Status != InvitationStatus.Pending)
            throw new NotFoundException("Invitation is expired or could not be found.");

        var inviteDeclined = await DeclineInviteAsync(invitation);
        if (!inviteDeclined)
            throw new ApplicationException("Failed to decline invite.");

        return true;
    }


    private async Task<bool> DeclineInviteAsync(Domain.Entities.Invitation invitation)
    {
        invitation.Status = InvitationStatus.Declined;
        invitation.ExpiresAt = invitation.UpdatedAt = DateTime.UtcNow;
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}