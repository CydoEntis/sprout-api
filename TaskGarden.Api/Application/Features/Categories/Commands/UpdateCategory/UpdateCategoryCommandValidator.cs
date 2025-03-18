using FluentValidation;
using TaskGarden.Application.Features.Shared.Constants;

namespace TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Category ID must be greater than zero.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required");

        RuleFor(x => x.Tag)
            .NotEmpty().WithMessage("Category tag is required")
            .Must(tag => CategoryConstants.Tags.Contains(tag)).WithMessage("Category tag is invalid")
            .WithMessage("Category tag is not valid. Please select a valid tag.");
    }
}