using FluentValidation;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskListWithCategory;

public class CreateTasklistWithCategoryCommandValidator : AbstractValidator<CreateTasklistWithCategoryCommand>
{
    public CreateTasklistWithCategoryCommandValidator()
    {
        RuleFor(x => x.TaskListName)
            .NotEmpty().WithMessage("Task list name is required.")
            .Length(3, 50).WithMessage("Task list name must be between 3 and 50 characters.");

        RuleFor(x => x.TaskListDescription)
            .MaximumLength(500).WithMessage("Task list description must not exceed 500 characters.");

        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Category name is required.")
            .Length(3, 50).WithMessage("Category name must be between 3 and 50 characters.")
            .When(x => !x.CategoryId.HasValue);

        RuleFor(x => x.CategoryTag)
            .NotEmpty().WithMessage("Category tag is required.")
            .Matches(@"^[a-zA-Z0-9_-]+$")
            .WithMessage("Category tag can only contain letters, numbers, hyphens, and underscores.")
            .MaximumLength(20).WithMessage("Category tag must not exceed 20 characters.")
            .When(x => !x.CategoryId.HasValue);

        RuleFor(x => x.CategoryColor)
            .NotEmpty().WithMessage("Category color is required.")
            .Matches(@"^#(?:[0-9a-fA-F]{3}){1,2}$")
            .WithMessage("Category color must be a valid hex code (e.g., #FFF or #FFFFFF).")
            .When(x => !x.CategoryId.HasValue);
    }
}