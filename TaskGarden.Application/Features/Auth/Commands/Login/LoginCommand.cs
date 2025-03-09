using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using ValidationException = FluentValidation.ValidationException;

namespace TaskGarden.Application.Features.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;

public class LoginResponse : BaseResponse
{
    public string AccessToken { get; set; } = string.Empty;
}

public class LoginCommandHandler(
    UserManager<AppUser> userManager,
    ITokenService tokenService,
    ICookieService cookieService,
    ISessionService sessionService,
    IValidator<LoginCommand> validator)
    : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new NotFoundException("User not found.");

        await sessionService.InvalidateAllSessionsByUserIdAsync(user.Id);
        var activeSession = await sessionService.GetActiveSessionAsync(user.Id);
        if (activeSession != null)
        {
            throw new ConflictException("User is already logged in.");
        }

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();

        await sessionService.CreateSessionAsync(user.Id, refreshToken);
        cookieService.Append(CookieConsts.RefreshToken, refreshToken.Token, true, refreshToken.ExpiryDate);

        return new LoginResponse { Message = "Logged in successfully", AccessToken = accessToken };
    }
}