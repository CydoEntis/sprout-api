using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Enums;

namespace TaskGarden.Application.Features.TaskList.Commands.DeleteTaskList;

public record DeleteTaskListCommand(int TaskListId) : IRequest<DeleteTaskListResponse>;

public class DeleteTaskListResponse : BaseResponse;

public class DeleteTaskListCommandHandler(
    IUserContextService userContextService,
    ITaskListRepository taskListRepository,
    ITaskListMemberRepository taskListMemberRepository,
    IValidationService validationService) : IRequestHandler<DeleteTaskListCommand, DeleteTaskListResponse>
{
    public async Task<DeleteTaskListResponse> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetAuthenticatedUserId();
        await validationService.ValidateRequestAsync(request, cancellationToken);

        var taskList = await GetTaskListByIdAsync(request.TaskListId);

        await CheckIfUserIsOwnerAsync(userId, taskList);

        await DeleteTaskListAndDependenciesAsync(taskList);

        return new DeleteTaskListResponse
        {
            Message = $"{taskList.Name} task list has been deleted successfully"
        };
    }

    private async Task<Domain.Entities.TaskList> GetTaskListByIdAsync(int taskListId)
    {
        var taskList = await taskListRepository.GetByIdAsync(taskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found");

        return taskList;
    }

    private async Task CheckIfUserIsOwnerAsync(string userId, Domain.Entities.TaskList taskList)
    {
        var member = await taskListMemberRepository.GetByUserAndTaskListAsync(userId, taskList.Id);
        if (member == null || member.Role != TaskListRole.Owner)
        {
            throw new UnauthorizedAccessException("You must be the owner of the task list to delete it.");
        }
    }

    private async Task DeleteTaskListAndDependenciesAsync(Domain.Entities.TaskList taskList)
    {
        var result = await taskListRepository.DeleteTaskListAndDependenciesAsync(taskList);
        if (!result)
            throw new ResourceModificationException("Task List could not be deleted.");
    }
}