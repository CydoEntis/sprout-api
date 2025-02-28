using FluentValidation;
using TaskGarden.Application.Features.TaskList.Commands.DeleteTaskListItem;

namespace TaskGarden.Application.Features.TaskListItem.Commands.DeleteTaskListItem;

public class DeleteTaskListItemCommandValidator : AbstractValidator<DeleteTaskListItemCommand>
{
    public DeleteTaskListItemCommandValidator()
    {
        RuleFor(x => x.TaskListItemId).GreaterThan(0).WithMessage("Invalid task list item ID");
    }
}