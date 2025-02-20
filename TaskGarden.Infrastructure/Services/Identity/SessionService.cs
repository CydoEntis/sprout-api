using TaskGarden.Application.Common;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Services.Identity;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<Session> GetSessionAsync(string refreshToken)
    {
        return await _sessionRepository.GetByRefreshToken(refreshToken);
    }

    public async Task CreateSessionAsync(string userId, RefreshToken refreshToken)
    {
        var sessionId = Guid.NewGuid().ToString();
        var session = new Session
        {
            UserId = userId,
            SessionId = sessionId,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpirationDate = refreshToken.ExpiryDate,
        };

        await _sessionRepository.AddAsync(session);
    }

    public async Task InvalidateSessionAsync(Session session)
    {
        session.IsVaild = false;
        session.RefreshTokenExpirationDate = DateTime.UtcNow;
        await _sessionRepository.UpdateAsync(session);
    }

    public async Task<bool> ValidateRefreshToken(string refreshToken)
    {
        var session = await _sessionRepository.GetByRefreshToken(refreshToken);
        return session != null && session.RefreshTokenExpirationDate > DateTime.UtcNow;
    }
}