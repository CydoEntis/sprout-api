using FluentValidation;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Features.Shared.Validators;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(ICategoryRepository categoryRepository,
        IUserContextService userContextService)
    {
        string[] validCategoryTags = [
            "shopping-bag", "shopping-basket", "shopping-cart", "users", "messages-square", "plane", "map-pinned",
            "receipt", "banknote", "hand-coins", "dumbbell", "heart-pulse", "roller-coaster", "ferris-wheel",
            "drama", "theater", "film", "house", "spray-can", "briefcase", "building", "building-2", "university",
            "book", "square-library"
        ];

        Include(new AuthenticatedValidator<CreateCategoryCommand>(userContextService));

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(50).WithMessage("Category name cannot exceed 100 characters");

        RuleFor(x => x.Tag)
            .NotEmpty().WithMessage("Category tag is required")
            .Must(tag => validCategoryTags.Contains(tag))
            .WithMessage("Category tag is not valid. Please select a valid tag.");

        RuleFor(x => x).MustAsync(async (command, _) =>
        {
            var userId = userContextService.GetUserId();
            if (userId == null) return false;
            var existingCategory = await categoryRepository.GetByNameAsync(userId, command.Name);
            return existingCategory == null;
        }).WithMessage("A category with this name already exists.");
    }
}