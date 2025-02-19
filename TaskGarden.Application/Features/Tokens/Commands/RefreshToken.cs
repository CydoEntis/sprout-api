using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Constants;
using TaskGarden.Application.Exceptions;
using TaskGarden.Application.Features.Auth.Commands.Login;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Data.Models;

namespace TaskGarden.Application.Features.Tokens.Commands;
public record RefreshTokensCommand : IRequest<RefreshTokensResponse>;

public class RefreshTokensResponse : BaseResponse
{
    public string AccessToken { get; set; } = string.Empty;
}


public class RefreshTokensCommandHandler(
    ICookieManager cookieManager,
    ISessionManager sessionManager,
    ITokenManager tokenManager,
    UserManager<AppUser> userManager)
    : IRequestHandler<RefreshTokensCommand, RefreshTokensResponse>
{
    public async Task<RefreshTokensResponse> Handle(RefreshTokensCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = cookieManager.Get(CookieConsts.RefreshToken);
        if (string.IsNullOrEmpty(refreshToken))
            throw new NotFoundException("Token not found");

        var session = await sessionManager.GetSessionAsync(refreshToken);
        if (session == null)
            throw new NotFoundException("Session not found");

        var user = await userManager.FindByIdAsync(session.UserId);
        if (user == null)
            throw new NotFoundException("User not found");

        var newAccessToken = tokenManager.GenerateAccessToken(user);
        var newRefreshToken = tokenManager.GenerateRefreshToken();

        await sessionManager.InvalidateSessionAsync(session);
        await sessionManager.CreateSessionAsync(user.Id, newRefreshToken);
        cookieManager.Append(CookieConsts.RefreshToken, newRefreshToken.Token, true, newRefreshToken.ExpiryDate);

        return new RefreshTokensResponse { Message = "Tokens refreshed successfully.", AccessToken = newAccessToken };
    }
}
