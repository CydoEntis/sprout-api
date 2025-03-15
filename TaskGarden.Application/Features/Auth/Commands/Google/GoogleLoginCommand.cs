using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.GoogleLogin;

public record GoogleLoginCommand(string AuthorizationCode) : IRequest<GoogleLoginResponse>;

public class GoogleLoginResponse : BaseResponse
{
    public string AccessToken { get; init; } = string.Empty;
}

public class GoogleLoginCommandHandler(
    UserManager<AppUser> userManager,
    IGoogleAuthService googleAuthService,
    IAuthSessionService authSessionService)
    : IRequestHandler<GoogleLoginCommand, GoogleLoginResponse>
{
    public async Task<GoogleLoginResponse> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
    {
        var googleUserInfo = await googleAuthService.GetUserInfoFromCodeAsync(request.AuthorizationCode)
                             ?? throw new InvalidTokenException("Invalid Google token");

        var user = await GetOrCreateUserAsync(googleUserInfo);
        var accessToken = await authSessionService.GenerateAndStoreTokensAsync(user);

        return new GoogleLoginResponse { Message = "Logged in successfully", AccessToken = accessToken };
    }

    private async Task<AppUser> GetOrCreateUserAsync(GoogleUserInfo googleUserInfo)
    {
        var user = await userManager.FindByEmailAsync(googleUserInfo.Email);
        if (user != null) return user;

        user = new AppUser
        {
            UserName = googleUserInfo.Email,
            Email = googleUserInfo.Email,
            FirstName = googleUserInfo.FirstName,
            LastName = googleUserInfo.LastName
        };

        await userManager.CreateAsync(user);
        return user;
    }
}