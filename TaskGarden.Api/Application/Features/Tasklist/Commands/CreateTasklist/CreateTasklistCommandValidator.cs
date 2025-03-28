using FluentValidation;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskList;

public class CreateTasklistCommandValidator : AbstractValidator<CreateTasklistCommand>
{
    public CreateTasklistCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name cannot be empty");
    }
}