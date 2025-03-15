using MediatR;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;

public class LoginResponse : BaseResponse
{
    public string AccessToken { get; init; } = string.Empty;
}

public class LoginCommandHandler(
    IUserService userService,
    IAuthSessionService authSessionService,
    IValidationService validationService)
    : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        await validationService.ValidateRequestAsync(request, cancellationToken);
        var user = await userService.GetUserByEmailAsync(request.Email);
        var accessToken = await authSessionService.GenerateAndStoreTokensAsync(user);

        return new LoginResponse { Message = "Logged in successfully", AccessToken = accessToken };
    }
}