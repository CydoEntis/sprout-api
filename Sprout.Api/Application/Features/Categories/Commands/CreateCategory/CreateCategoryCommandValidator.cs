using FluentValidation;
using Sprout.Application.Features.Shared.Constants;

namespace Sprout.Api.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required");

        RuleFor(x => x.Tag)
            .NotEmpty().WithMessage("Category tag is required")
            .Must(tag => CategoryConstants.Tags.Contains(tag))
            .WithMessage("Category tag is not valid. Please select a valid tag.");
    }
}