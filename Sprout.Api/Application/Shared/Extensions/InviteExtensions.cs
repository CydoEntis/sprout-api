using Microsoft.EntityFrameworkCore;
using Sprout.Api.Domain.Entities;

namespace Sprout.Api.Application.Shared.Extensions;

public static class InviteExtensions
{
    public static async Task<Invitation?> GetByInviteTokenAsync(this DbSet<Invitation> invitations, string inviteToken)
    {
        return await invitations.FirstOrDefaultAsync(i => i.Token == inviteToken);
    }
}