using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Api.Services.Implementations;

public class SessionManager
{
    private readonly ISessionRepository _sessionRepository;

    public SessionManager(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
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
    }

    public async Task<bool> ValidateRefreshToken(string refreshToken)
    {
        var session = await _sessionRepository.GetByRefreshToken(refreshToken);
        return session != null && session.RefreshTokenExpirationDate > DateTime.Now;
    }
}