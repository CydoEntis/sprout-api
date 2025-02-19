using TaskGarden.Application.Common;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Services.Contracts;

public interface ISessionService
{
    Task<Session> GetSessionAsync(string refreshToken);
    Task CreateSessionAsync(string userId, RefreshToken refreshToken);
    Task InvalidateSessionAsync(Session session);
    Task<bool> ValidateRefreshToken(string refreshToken);
}