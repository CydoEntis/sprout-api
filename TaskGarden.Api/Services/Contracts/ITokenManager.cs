using TaskGarden.Data.Models;

namespace TaskGarden.Api.Services.Contracts;

public interface ITokenManager
{
    string GenerateAccessToken(AppUser user);
    RefreshToken GenerateRefreshToken();
}