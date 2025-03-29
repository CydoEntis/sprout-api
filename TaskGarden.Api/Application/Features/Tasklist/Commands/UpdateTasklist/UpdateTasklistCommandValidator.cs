using FluentValidation;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.UpdateTaskList;

public class UpdateTasklistCommandValidator : AbstractValidator<UpdateTasklistCommand>
{
    public UpdateTasklistCommandValidator()
    {
        RuleFor(x => x.TasklistId)
            .NotEmpty().WithMessage("Id must be provided")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
    }
}