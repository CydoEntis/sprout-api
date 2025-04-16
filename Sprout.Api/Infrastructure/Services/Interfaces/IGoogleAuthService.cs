using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Infrastructure.Services.Interfaces;

public interface IGoogleAuthService
{
    Task<GoogleUserInfo?> GetUserInfoFromCodeAsync(string authorizationCode);
}