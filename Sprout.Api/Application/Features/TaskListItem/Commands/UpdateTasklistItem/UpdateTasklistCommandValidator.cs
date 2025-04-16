using FluentValidation;
using Sprout.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;

namespace Sprout.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;

public class UpdateTaskListItemCommandValidator : AbstractValidator<UpdateTasklistItemCommand>
{
    public UpdateTaskListItemCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
    }
}