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
    public string AccessToken { get; init; } = string.Empty;
}

public class LoginCommandHandler(
    UserManager<AppUser> userManager,
    IAuthSessionService authSessionService,
    IValidator<LoginCommand> validator)
    : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        await ValidateRequestAsync(request, cancellationToken);
        var user = await GetUserByEmailAsync(request.Email);
        var accessToken = await authSessionService.GenerateAndStoreTokensAsync(user);

        return new LoginResponse { Message = "Logged in successfully", AccessToken = accessToken };
    }

    private async Task ValidateRequestAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
    }

    private async Task<AppUser> GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email)
               ?? throw new NotFoundException("User not found.");
    }
}