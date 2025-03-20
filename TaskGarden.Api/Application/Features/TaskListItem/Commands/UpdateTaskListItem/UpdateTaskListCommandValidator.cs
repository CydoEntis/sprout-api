using FluentValidation;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;

public class UpdateTaskListItemCommandValidator : AbstractValidator<UpdateTaskListItemCommand>
{
    public UpdateTaskListItemCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
    }
}