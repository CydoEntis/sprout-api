using Microsoft.EntityFrameworkCore;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Api.Application.Shared.Extensions;

public static class InviteExtensions
{
    public static async Task<Invitation?> GetByInviteToken(this DbSet<Invitation> invitations, string inviteToken)
    {
        return await invitations.FirstOrDefaultAsync(i => i.Token == inviteToken);
    }
}