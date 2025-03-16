using FluentValidation;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Features.Shared.Constants;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Categories.Commands.CreateCategory;

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