using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Api.Infrastructure.Services.Interfaces;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Infrastructure.Services.Identity;

public class SessionService : ISessionService
{
    private readonly AppDbContext _context;

    public SessionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Session?> GetSessionByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Sessions.FirstOrDefaultAsync(s => s.RefreshToken == refreshToken);
    }

    public async Task<Session?> GetSessionByUserIdAsync(string userId)
    {
        return await _context.Sessions.FirstOrDefaultAsync(s => s.UserId == userId);
    }

    public async Task<Session> CreateSessionAsync(string userId, RefreshToken refreshToken)
    {
        var sessionId = Guid.NewGuid().ToString();
        var session = new Session
        {
            UserId = userId,
            SessionId = sessionId,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpirationDate = refreshToken.ExpiryDate,
        };

        await _context.AddAsync(session);
        await _context.SaveChangesAsync();
        return session;
    }

    public async Task InvalidateSessionAsync(Session session)
    {
        session.RefreshTokenExpirationDate = DateTime.UtcNow;
        _context.Update(session);
        await _context.SaveChangesAsync();
    }

    public async Task InvalidateAllSessionsByUserIdAsync(string userId)
    {
        var sessions = await _context.Sessions.Where(s => s.UserId == userId).ToListAsync();

        foreach (var session in sessions)
        {
            if (session.RefreshTokenExpirationDate < DateTime.UtcNow)
            {
                session.RefreshTokenExpirationDate = DateTime.UtcNow;
                _context.Update(session);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task<bool> ValidateRefreshToken(string refreshToken)
    {
        var session = await GetSessionByRefreshTokenAsync(refreshToken);
        return session != null && session.RefreshTokenExpirationDate > DateTime.UtcNow;
    }

    public async Task<Session?> GetActiveSessionAsync(string userId)
    {
        return await _context.Sessions
            .FirstOrDefaultAsync(s =>
                s.UserId == userId &&
                s.RefreshTokenExpirationDate > DateTime.UtcNow);
        ;
    }
}