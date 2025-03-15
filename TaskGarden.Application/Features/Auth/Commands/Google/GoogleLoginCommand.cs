using MediatR;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.Google;

public record GoogleLoginCommand(string AuthorizationCode) : IRequest<GoogleLoginResponse>;

public class GoogleLoginResponse : BaseResponse
{
    public string AccessToken { get; init; } = string.Empty;
}

public class GoogleLoginCommandHandler(
    IUserService userService,
    IGoogleAuthService googleAuthService,
    IAuthSessionService authSessionService,
    IValidationService validationService)
    : IRequestHandler<GoogleLoginCommand, GoogleLoginResponse>
{
    public async Task<GoogleLoginResponse> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
    {
        await validationService.ValidateRequestAsync(request, cancellationToken);

        var googleUserInfo = await googleAuthService.GetUserInfoFromCodeAsync(request.AuthorizationCode)
                             ?? throw new InvalidTokenException("Invalid Google token");

        var user = await GetOrCreateUserAsync(googleUserInfo);

        var accessToken = await authSessionService.GenerateAndStoreTokensAsync(user);

        return new GoogleLoginResponse { Message = "Logged in successfully", AccessToken = accessToken };
    }

    private async Task<AppUser> GetOrCreateUserAsync(GoogleUserInfo googleUserInfo)
    {
        var user = await userService.GetUserByEmailAsync(googleUserInfo.Email);
        if (user != null) return user;

        // If no user exists, create one
        user = new AppUser
        {
            UserName = googleUserInfo.Email,
            Email = googleUserInfo.Email,
            FirstName = googleUserInfo.FirstName,
            LastName = googleUserInfo.LastName
        };

        await userService.CreateUserAsync(user);
        return user;
    }
}