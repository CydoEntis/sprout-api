using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Auth.Commands.Login;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.GoogleLogin;

public record GoogleLoginCommand(string AuthorizationCode) : IRequest<GoogleLoginResponse>;

public class GoogleLoginResponse : BaseResponse
{
    public string AccessToken { get; set; } = string.Empty;
}

public class GoogleLoginCommandHandler(
    UserManager<AppUser> userManager,
    ITokenService tokenService,
    ICookieService cookieService,
    ISessionService sessionService,
    IGoogleAuthService googleAuthService)
    : IRequestHandler<GoogleLoginCommand, GoogleLoginResponse>
{
    public async Task<GoogleLoginResponse> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
    {
        var googleUserInfo = await googleAuthService.GetUserInfoFromCodeAsync(request.AuthorizationCode);

        if (googleUserInfo == null)
            throw new UnauthorizedAccessException("Invalid Google token.");

        var user = await userManager.FindByEmailAsync(googleUserInfo.Email);
        if (user == null)
        {
            user = new AppUser
            {
                UserName = googleUserInfo.Email,
                Email = googleUserInfo.Email,
                FirstName = googleUserInfo.FirstName,
                LastName = googleUserInfo.LastName
            };
            await userManager.CreateAsync(user);
        }

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();

        var session = await sessionService.CreateSessionAsync(user.Id, refreshToken);

        cookieService.Append(CookieConsts.RefreshToken, refreshToken.Token, true, refreshToken.ExpiryDate);
        cookieService.Append(CookieConsts.SessionId, session.SessionId, true, refreshToken.ExpiryDate);


        return new GoogleLoginResponse { Message = "Logged in successfully", AccessToken = accessToken };
    }
}