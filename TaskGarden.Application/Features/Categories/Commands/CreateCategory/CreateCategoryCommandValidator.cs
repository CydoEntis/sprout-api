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
        Include(new AuthenticatedValidator<CreateCategoryCommand>(userContextService));

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(50).WithMessage("Category name cannot exceed 100 characters");


        RuleFor(x => x).MustAsync(async (command, _) =>
        {
            var userId = userContextService.GetUserId();
            if (userId == null) return false;
            var existingCategory = await categoryRepository.GetByNameAsync(userId, command.Name);
            return existingCategory == null;
        });
    }
}