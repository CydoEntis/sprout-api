using FluentValidation;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Application.Features.Shared.Validators;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Category ID must be greater than zero.");
    }
}