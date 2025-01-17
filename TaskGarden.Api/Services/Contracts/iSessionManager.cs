using TaskGarden.Data.Models;

namespace TaskGarden.Api.Services.Contracts;

public interface ISessionManager
{
    Task CreateSessionAsync(string userId, RefreshToken refreshToken);
    Task<bool> ValidateRefreshToken(string refreshToken);
}