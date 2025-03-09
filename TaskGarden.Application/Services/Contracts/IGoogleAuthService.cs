using TaskGarden.Application.Features.Shared.Models;

namespace TaskGarden.Application.Services.Contracts;

public interface IGoogleAuthService
{
    Task<GoogleUserInfo?> GetUserInfoFromCodeAsync(string authorizationCode);
}