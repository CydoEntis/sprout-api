using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Services.Identity;

public class AuthSessionService(
    ITokenService tokenService,
    ISessionService sessionService,
    ICookieService cookieService) : IAuthSessionService
{
    public async Task<string> GenerateAndStoreTokensAsync(AppUser user)
    {
        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();

        var session = await sessionService.CreateSessionAsync(user.Id, refreshToken);

        cookieService.Append(CookieConsts.RefreshToken, refreshToken.Token, httpOnly: true, refreshToken.ExpiryDate);
        cookieService.Append(CookieConsts.SessionId, session.SessionId, httpOnly: true, refreshToken.ExpiryDate);

        return accessToken;
    }
}