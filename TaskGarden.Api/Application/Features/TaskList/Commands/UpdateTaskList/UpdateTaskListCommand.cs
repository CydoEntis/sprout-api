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
    IValidationService validationService,
    IMapper mapper) : IRequestHandler<UpdateTaskListCommand, UpdateTaskListResponse>
{
    public async Task<UpdateTaskListResponse> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetAuthenticatedUserId() ??
                     throw new UnauthorizedAccessException("User not authenticated");

        // Validate the request
        await validationService.ValidateRequestAsync(request, cancellationToken);

        await EnsureUserHasPermissionAsync(userId, request.TaskListId);

        var taskList = await GetTaskListAsync(request.TaskListId);
        mapper.Map(request, taskList);
        taskList.UpdatedAt = DateTime.UtcNow;

        await taskListRepository.UpdateAsync(taskList);

        return new UpdateTaskListResponse
        {
            Message = $"Task list with ID {taskList.Id} updated successfully",
            TaskListId = taskList.Id
        };
    }

    private async Task EnsureUserHasPermissionAsync(string userId, int taskListId)
    {
        var userRole = await GetUserRoleAsync(userId, taskListId);

        if (userRole is not (TaskListRole.Owner or TaskListRole.Editor))
            throw new PermissionException("You do not have permission to update this task list");
    }

    private async Task<TaskListRole> GetUserRoleAsync(string userId, int taskListId)
    {
        var roleString = await taskListMemberRepository.GetAssignedRoleAsync(userId, taskListId);
        if (!Enum.TryParse(roleString, out TaskListRole role))
            throw new PermissionException("Invalid role");

        return role;
    }

    private async Task<Domain.Entities.TaskList> GetTaskListAsync(int taskListId)
    {
        var taskList = await taskListRepository.GetAsync(taskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found");

        return taskList;
    }
}