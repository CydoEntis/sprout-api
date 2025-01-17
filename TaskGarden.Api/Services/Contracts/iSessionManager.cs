using TaskGarden.Data.Models;

namespace TaskGarden.Api.Services.Contracts;

public interface ISessionManager
{
    Task<Session> GetSessionAsync(string refreshToken);
    Task CreateSessionAsync(string userId, RefreshToken refreshToken);
    Task InvalidateSessionAsync(Session session);
    Task<bool> ValidateRefreshToken(string refreshToken);
}