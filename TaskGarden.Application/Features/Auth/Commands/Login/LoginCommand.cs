using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Constants;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Services.Implementations.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;

public class BaseResponse
{
    public string Message { get; set; } = string.Empty;
}

public class LoginResponse : BaseResponse
{
    public string AccessToken { get; set; } = string.Empty;
}

public class LoginCommandHandler(
    UserManager<AppUser> userManager,
    ITokenManager tokenManager,
    ICookieManager cookieManager,
    ISessionManager sessionManager,
    IValidator<LoginCommand> validator)
    : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await userManager.FindByEmailAsync(request.Email);
        var accessToken = tokenManager.GenerateAccessToken(user);
        var refreshToken = tokenManager.GenerateRefreshToken();

        await sessionManager.CreateSessionAsync(user.Id, refreshToken);
        cookieManager.Append(CookieConsts.RefreshToken, refreshToken.Token, true, refreshToken.ExpiryDate);

        return new LoginResponse() { Message = "Logged in successfully", AccessToken = accessToken };
    }
}