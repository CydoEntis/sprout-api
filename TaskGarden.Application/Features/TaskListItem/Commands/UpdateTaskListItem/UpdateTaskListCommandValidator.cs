using FluentValidation;

namespace TaskGarden.Application.Features.TaskListItem.Commands.UpdateTaskListItem;

public class UpdateTaskListItemCommandValidator : AbstractValidator<UpdateTaskListItemCommand>
{
    public UpdateTaskListItemCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
    }
}