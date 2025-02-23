using FluentValidation;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Shared.Validators;

public class AuthenticatedValidator<T> : AbstractValidator<T>
{
    public AuthenticatedValidator(IUserContextService userContextService)
    {
        RuleFor(x => x)
            .Must(_ => userContextService.GetUserId() != null)
            .WithMessage("User is not authenticated");
    }
}