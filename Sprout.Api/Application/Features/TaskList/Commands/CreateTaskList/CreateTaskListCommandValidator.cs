using FluentValidation;

namespace Sprout.Api.Application.Features.TaskList.Commands.CreateTaskList;

public class CreateTaskListCommandValidator : AbstractValidator<CreateTaskListCommand>
{
    public CreateTaskListCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name cannot be empty");
    }
}