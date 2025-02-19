using FluentValidation;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Data.Models;

namespace TaskGarden.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandValidator(UserManager<AppUser> userManager)
    {
        _userManager = userManager;

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format")
            .MustAsync(BeUniqueEmail).WithMessage("Email already in use");
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken token)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);
        return existingUser is null;
    }
}