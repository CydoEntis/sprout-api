using MediatR;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.DeleteTaskListItem;

public record DeleteTasklistItemCommand(int TaskListItemId) : IRequest<DeleteTaskListItemResponse>;

public class DeleteTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class DeleteTaskListItemCommandHandler : AuthRequiredHandler,
    IRequestHandler<DeleteTasklistItemCommand, DeleteTaskListItemResponse>
{
    private readonly AppDbContext _context;

    public DeleteTaskListItemCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<DeleteTaskListItemResponse> Handle(DeleteTasklistItemCommand request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var taskListItem = await _context.TasklistItems.ExistsAsync(request.TaskListItemId);
        if (taskListItem == null)
            throw new NotFoundException("Task list item not found.");

        var taskList = await _context.Tasklists.GetByIdAsync(taskListItem.TasklistId);
        if (taskList == null)
            throw new NotFoundException("Task list not found.");

        if (!await _context.TasklistMembers.IsOwnerOrEditorAsync(userId, taskList.Id))
            throw new UnauthorizedAccessException("You are not authorized to delete items from this task list.");


        if (!await DeleteTaskListItem(taskListItem))
            throw new ResourceModificationException("Task list item could not be deleted.");

        return new DeleteTaskListItemResponse()
        {
            Message = $"Item with id: {taskListItem.Id} has been deleted successfully.",
            TaskListId = taskListItem.TasklistId
        };
    }

    private async Task<bool> DeleteTaskListItem(Domain.Entities.TasklistItem tasklistItem)
    {
        _context.TasklistItems.Remove(tasklistItem);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}