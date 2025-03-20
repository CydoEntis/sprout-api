using FluentValidation;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItemCompletedStatus;

public class
    UpdateTaskListItemCompletedStatusCommandValidator : AbstractValidator<UpdateTaskListItemCompletedStatusCommand>
{
    public UpdateTaskListItemCompletedStatusCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("TaskListItem Id must be greater than zero.");
    }
}