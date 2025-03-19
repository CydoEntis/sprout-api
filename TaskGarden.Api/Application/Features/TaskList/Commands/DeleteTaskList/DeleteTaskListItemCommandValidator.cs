using FluentValidation;
using TaskGarden.Api.Application.Features.TaskList.Commands.DeleteTaskList;

public class DeleteTaskListCommandValidator : AbstractValidator<DeleteTaskListCommand>
{
    public DeleteTaskListCommandValidator()
    {
        RuleFor(x => x.TaskListId)
            .GreaterThan(0)
            .WithMessage("Task list ID must be greater than zero.");
    }
}