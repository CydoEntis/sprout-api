using FluentValidation;

namespace Sprout.Api.Application.Features.Auth.Commands.Google
{
    public class GoogleLoginCommandValidator : AbstractValidator<GoogleLoginCommand>
    {
        public GoogleLoginCommandValidator()
        {
            RuleFor(x => x.AuthorizationCode)
                .NotEmpty().WithMessage("Authorization code is required.");
        }
    }
}