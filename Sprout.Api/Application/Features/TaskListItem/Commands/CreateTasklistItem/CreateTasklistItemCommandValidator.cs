using FluentValidation;

namespace Sprout.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;

public class CreateTasklistItemCommandValidator : AbstractValidator<CreateTasklistItemCommand>
{
    public CreateTasklistItemCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");

        RuleFor(x => x.TaskListId)
            .GreaterThan(0).WithMessage("TaskListId must be greater than zero.");
    }
}