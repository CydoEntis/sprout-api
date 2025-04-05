using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Invitation.Commands.DeclineInvite;

public record DeclineInviteCommand(string Token) : IRequest<bool>;

public class DeclineInviteCommandHandler
    : AuthRequiredHandler, IRequestHandler<DeclineInviteCommand, bool>
{
    private readonly AppDbContext _context;

    public DeclineInviteCommandHandler(AppDbContext context) : base(null)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeclineInviteCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var user = await _context.Users
            .Where(u => u.Id == userId)
            .Select(u => u.Email)
            .FirstOrDefaultAsync();

        if (user == null)
            throw new NotFoundException("User not found.");

        var invitation = await _context.Invitations.GetByInviteTokenAsync(request.Token);

        if (invitation == null || invitation.Status != InvitationStatus.Pending)
            throw new NotFoundException("Invitation is expired or could not be found.");

        if (invitation.InvitedUserEmail != user)
            throw new UnauthorizedAccessException("You are not authorized to decline this invite.");

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