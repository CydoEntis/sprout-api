using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;

namespace TaskGarden.Application.Features.TaskList.Commands.CreateTaskList;

public record CreateTaskListCommand(string Name, string Description, string CategoryName)
    : IRequest<CreateTaskListResponse>;

public class CreateTaskListResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class CreateTaskListCommandHandler(
    IUserContextService userContextService,
    ITaskListRepository taskListRepository,
    ICategoryRepository categoryRepository,
    ITaskListAssignmentRepository taskListAssignmentRepository,
    IValidator<CreateTaskListCommand> validator,
    IMapper mapper) : IRequestHandler<CreateTaskListCommand, CreateTaskListResponse>
{
    public async Task<CreateTaskListResponse> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var category = await categoryRepository.GetByNameAsync(userId, request.CategoryName);

        var taskList = mapper.Map<Domain.Entities.TaskList>(request);
        taskList.CreatedById = userId;
        taskList.CategoryId = category.Id;


        await taskListRepository.AddAsync(taskList);
        var response = await AssignUserToTaskListAsync(userId, taskList.Id, TaskListRole.Owner);
        if (!response)
            throw new ResourceCreationException("Unable to assign user to task list.");

        return new CreateTaskListResponse() { Message = $"Task list created: {taskList.Id}", TaskListId = taskList.Id };
    }

    // Potentially move into its own class for reusability.
    private async Task<bool> AssignUserToTaskListAsync(string userId, int taskListId, TaskListRole role)
    {
        try
        {
            var userTaskList = new TaskListAssignments
            {
                UserId = userId,
                TaskListId = taskListId,
                Role = role.ToString()
            };

            await taskListAssignmentRepository.AddAsync(userTaskList);
            return true;
        }
        catch
        {
            return false;
        }
    }
}