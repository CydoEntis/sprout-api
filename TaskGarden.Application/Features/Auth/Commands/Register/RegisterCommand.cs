using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Data.Models;

namespace TaskGarden.Application.Features.Auth.Commands.Register;

public record RegisterCommand(string Email, string FirstName, string LastName, string Password)
    : IRequest<RegisterResponse>;

public class RegisterResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
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

    public Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

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