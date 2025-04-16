using FluentValidation;

namespace Sprout.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItemCompletedStatus;

public class
    UpdateTasklistItemCompletedStatusCommandValidator : AbstractValidator<UpdateTaskListItemCompletedStatusCommand>
{
    public UpdateTasklistItemCompletedStatusCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("TaskListItem Id must be greater than zero.");
    }
}