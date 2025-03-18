using Microsoft.EntityFrameworkCore;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;

namespace TaskGarden.Infrastructure.Repositories.Implementations;

public class InvitationRepository : BaseRepository<Invitation>, IInvitationRepository
{
    public InvitationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Invitation?> GetByTokenAsync(string token)
    {
        return await _context.Invitations
            .FirstOrDefaultAsync(i => i.Token == token);
    }

    public async Task<List<Invitation>> GetPendingInvitationsByEmailAsync(string email)
    {
        return await _context.Invitations
            .Where(i => i.InvitedUserEmail == email && i.Status == InvitationStatus.Pending)
            .ToListAsync();
    }


    public async Task<bool> InvitationExistsAsync(string email, int taskListId)
    {
        return await _context.Invitations
            .AnyAsync(i => i.InvitedUserEmail == email &&
                           i.TaskListId == taskListId &&
                           i.Status == InvitationStatus.Pending);
    }
}