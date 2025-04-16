using FluentValidation;

namespace Sprout.Api.Application.Features.TaskList.Commands.UpdateTaskList;

public class UpdateTaskListCommandValidator : AbstractValidator<UpdateTaskListCommand>
{
    public UpdateTaskListCommandValidator()
    {
        RuleFor(x => x.TasklistId)
            .NotEmpty().WithMessage("Id must be provided")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
    }
}