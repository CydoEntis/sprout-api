using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Categories.Commands.DeleteCategory;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.TaskList.Commands.DeleteTaskList;

public record DeleteTaskListCommand(int TaskListId) : IRequest<DeleteTaskListResponse>;

public class DeleteTaskListResponse : BaseResponse;

public class DeleteTaskListCommandHandler(
    IUserContextService userContextService,
    ITaskListRepository taskListRepository,
    IValidator<DeleteTaskListCommand> validator) : IRequestHandler<DeleteTaskListCommand, DeleteTaskListResponse>
{
    public async Task<DeleteTaskListResponse> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetAuthenticatedUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // TODO: In future Add role check, is user an Owner/Editor then allow them to delete the task list.

        var taskList = await taskListRepository.GetByIdAsync(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found");

        var result = await taskListRepository.DeleteTaskListAndDependenciesAsync(taskList);
        if (!result)
            throw new ResourceModificationException("Task List could not be deleted.");

        return new DeleteTaskListResponse() { Message = $"{taskList.Name} task list has been deleted successfully" };
    }
}