using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Infrastructure.Services.Interfaces;

public interface ISessionService
{
    Task<Session?> GetSessionByRefreshTokenAsync(string refreshToken);
    Task<Session?> GetSessionByUserIdAsync(string userId);
    Task<Session> CreateSessionAsync(string userId, RefreshToken refreshToken);
    Task InvalidateSessionAsync(Session session);
    Task<bool> ValidateRefreshToken(string refreshToken);
    Task InvalidateAllSessionsByUserIdAsync(string userId);
    Task<Session?> GetActiveSessionAsync(string userId);
}