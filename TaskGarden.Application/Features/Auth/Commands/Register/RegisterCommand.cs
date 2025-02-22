using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Auth.Commands.Login;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.Register;

public record RegisterCommand(string Email, string FirstName, string LastName, string Password)
    : IRequest<LoginResponse>;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, LoginResponse>
{
    private readonly IMediator _mediator;
    private readonly UserManager<AppUser> _userManager;
    private readonly IValidator<RegisterCommand> _validator;


    public RegisterCommandHandler(IMediator mediator, UserManager<AppUser> userManager,
        IValidator<RegisterCommand> validator)
    {
        _mediator = mediator;
        _userManager = userManager;
        _validator = validator;
    }

    public async Task<LoginResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new FluentValidation.ValidationException(validationResult.Errors);

        var user = new AppUser
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new ResourceCreationException("Registration failed");

        return await _mediator.Send(new LoginCommand(request.Email, request.Password), cancellationToken);
    }
}