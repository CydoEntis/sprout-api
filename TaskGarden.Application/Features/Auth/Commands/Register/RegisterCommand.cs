using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Auth.Commands.Login;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.Register;

public record RegisterCommand(string Email, string FirstName, string LastName, string Password)
    : IRequest<LoginResponse>;

public class RegisterCommandHandler(
    IMediator mediator,
    IUserService userService,
    ITokenService tokenService,
    IValidationService validationService) : IRequestHandler<RegisterCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await validationService.ValidateRequestAsync(request, cancellationToken);
        
        var user = new AppUser
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        await userService.CreateUserAsync(user, request.Password);

        return await mediator.Send(new LoginCommand(request.Email, request.Password), cancellationToken);
    }
}