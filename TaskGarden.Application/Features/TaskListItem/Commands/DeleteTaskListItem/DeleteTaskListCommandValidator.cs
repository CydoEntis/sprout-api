using FluentValidation;

namespace TaskGarden.Application.Features.TaskList.Commands.DeleteTaskListItem;

public class DeleteTaskListItemCommandValidator : AbstractValidator<DeleteTaskListItemCommand>
{
    public DeleteTaskListItemCommandValidator()
    {
        RuleFor(x => x.TaskListItemId).GreaterThan(0).WithMessage("Invalid task list item ID");
    }
}