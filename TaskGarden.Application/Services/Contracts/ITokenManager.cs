using TaskGarden.Data.Models;

namespace TaskGarden.Application.Services.Contracts;

public interface ITokenManager
{
    string GenerateAccessToken(AppUser user);
    RefreshToken GenerateRefreshToken();
    Task<bool> IsRefreshTokenValid(string token);
}