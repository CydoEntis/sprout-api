using FluentValidation;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;

public class GetAllTasklistsForCategoryQueryValidator : AbstractValidator<GetAllTasklistsForCategoryQuery>
{
    public GetAllTasklistsForCategoryQueryValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Category name is required");
    }
}