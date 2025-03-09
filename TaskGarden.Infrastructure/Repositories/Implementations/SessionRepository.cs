using Microsoft.EntityFrameworkCore;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Implementations;

public class SessionRepository : BaseRepository<Session>, ISessionRepository
{
    public SessionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Session> GetByUserId(string userId)
    {
        return await _context.Sessions.FirstOrDefaultAsync(s => s.UserId == userId);
    }


    public async Task<Session> GetByRefreshToken(string refreshToken)
    {
        return await _context.Sessions.FirstOrDefaultAsync(s => s.RefreshToken == refreshToken);
    }

    public async Task<List<Session>> GetAllByUserId(string userId)
    {
        return await _context.Sessions.Where(s => s.UserId == userId).ToListAsync();
    }

    public async Task<Session?> GetActiveSessionByUserIdAsync(string userId)
    {
        return await _context.Sessions
            .FirstOrDefaultAsync(s =>
                s.UserId == userId &&
                s.IsVaild &&
                s.RefreshTokenExpirationDate > DateTime.UtcNow);
    }
}