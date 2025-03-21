using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Application.Features.Auth.Commands.Login;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Application.Features.Auth.Commands.Register;

public record RegisterCommand(string Email, string FirstName, string LastName, string Password)
    : IRequest<LoginResponse>;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, LoginResponse>
{
    private readonly IValidator<RegisterCommand> _validator;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMediator _mediator;

    public RegisterCommandHandler(IValidator<RegisterCommand> validator, UserManager<AppUser> userManager,
        IMediator mediator)
    {
        _validator = validator;
        _userManager = userManager;
        _mediator = mediator;
    }

    public async Task<LoginResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = new AppUser
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        await _userManager.CreateAsync(user, request.Password);

        return await _mediator.Send(new LoginCommand(request.Email, request.Password), cancellationToken);
    }
}