using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Enums;

namespace TaskGarden.Application.Features.TaskList.Commands.UpdateTaskList;

public record UpdateTaskListCommand(int TaskListId, string Name, string Description) : IRequest<UpdateTaskListResponse>;

public class UpdateTaskListResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class UpdateTaskListCommandHandler(
    IUserContextService userContextService,
    ITaskListRepository taskListRepository,
    ITaskListMemberRepository taskListMemberRepository,
    IValidator<UpdateTaskListCommand> validator,
    IMapper mapper) : IRequestHandler<UpdateTaskListCommand, UpdateTaskListResponse>
{
    public async Task<UpdateTaskListResponse> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        
        var userRoleString = await taskListMemberRepository.GetAssignedRoleAsync(userId, request.TaskListId);

        if (!Enum.TryParse<TaskListRole>(userRoleString, out var userRole))
        {
            throw new PermissionException("Invalid role");
        }

        if (userRole != TaskListRole.Owner && userRole != TaskListRole.Editor)
            throw new PermissionException("You do not have permission to update this task list");


        var taskList = await taskListRepository.GetAsync(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found");

        mapper.Map(request, taskList);

        taskList.UpdatedAt = DateTime.UtcNow;

        await taskListRepository.UpdateAsync(taskList);
        return new UpdateTaskListResponse()
            { Message = $"Task list with {taskList.Id} updated", TaskListId = taskList.Id };
    }
}