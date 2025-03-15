using FluentValidation;

namespace TaskGarden.Application.Features.Auth.Commands.Google
{
    public class GoogleLoginCommandValidator : AbstractValidator<GoogleLoginCommand>
    {
        public GoogleLoginCommandValidator()
        {
            RuleFor(x => x.AuthorizationCode)
                .NotEmpty().WithMessage("Authorization code is required.")
                .Matches(@"^[A-Za-z0-9\-._~%]{1,255}$").WithMessage("Invalid authorization code format.");
        }
    }
}