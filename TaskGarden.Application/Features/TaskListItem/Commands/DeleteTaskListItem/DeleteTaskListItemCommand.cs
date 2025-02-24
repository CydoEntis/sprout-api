using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.TaskList.Commands.DeleteTaskListItem;

public record DeleteTaskListItemCommand(int TaskListItemId) : IRequest<DeleteTaskListItemResponse>;

public class DeleteTaskListItemResponse : BaseResponse;

public class DeleteTaskListItemCommandHandler(
    IUserContextService userContextService,
    ITaskListItemRepository taskListItemRepository
    // IValidator<DeleteTaskListItemCommand> validator
) : IRequestHandler<DeleteTaskListItemCommand, DeleteTaskListItemResponse>
{
    public async Task<DeleteTaskListItemResponse> Handle(DeleteTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        // var validationResult = await validator.ValidateAsync(request, cancellationToken);
        // if (!validationResult.IsValid)
        //     throw new ValidationException(validationResult.Errors);

        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var taskListItem = await taskListItemRepository.GetByIdAsync(request.TaskListItemId);
        if (taskListItem == null)
            throw new NotFoundException("Task list item not found.");


        var result = await taskListItemRepository.DeleteAsync(taskListItem.Id);
        if (!result)
            throw new ResourceModificationException("Category could not be deleted.");

        return new DeleteTaskListItemResponse()
            { Message = $"Item with id: {taskListItem.Id}  has been deleted successfully" };
    }
}