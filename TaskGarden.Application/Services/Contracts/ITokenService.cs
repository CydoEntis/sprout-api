using TaskGarden.Application.Common;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Services.Contracts;

public interface ITokenService
{
    string GenerateAccessToken(AppUser user);
    RefreshToken GenerateRefreshToken();
    Task<bool> IsRefreshTokenValid(string token);
}