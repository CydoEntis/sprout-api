using TaskGarden.Application.Features.Shared.Models;

namespace TaskGarden.Api.Infrastructure.Services.Interfaces;

public interface IGoogleAuthService
{
    Task<GoogleUserInfo?> GetUserInfoFromCodeAsync(string authorizationCode);
}