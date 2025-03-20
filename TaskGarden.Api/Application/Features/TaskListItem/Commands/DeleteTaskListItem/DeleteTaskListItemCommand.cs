using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.DeleteTaskListItem;

public record DeleteTaskListItemCommand(int TaskListItemId) : IRequest<DeleteTaskListItemResponse>;

public class DeleteTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class DeleteTaskListItemCommandHandler : AuthRequiredHandler,
    IRequestHandler<DeleteTaskListItemCommand, DeleteTaskListItemResponse>
{
    private readonly AppDbContext _context;

    public DeleteTaskListItemCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<DeleteTaskListItemResponse> Handle(DeleteTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var taskListItem = await _context.TaskListItems.ExistsAsync(request.TaskListItemId);
        if (taskListItem == null)
            throw new NotFoundException("Task list item not found.");

        var taskList = await _context.TaskLists.GetByIdAsync(taskListItem.TaskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found.");

        if (!await _context.TaskListMembers.IsOwnerOrEditorAsync(userId, taskList.Id))
            throw new UnauthorizedAccessException("You are not authorized to delete items from this task list.");


        if (!await DeleteTaskListItem(taskListItem))
            throw new ResourceModificationException("Task list item could not be deleted.");

        return new DeleteTaskListItemResponse()
        {
            Message = $"Item with id: {taskListItem.Id} has been deleted successfully.",
            TaskListId = taskListItem.TaskListId
        };
    }

    private async Task<bool> DeleteTaskListItem(Domain.Entities.TaskListItem taskListItem)
    {
        _context.TaskListItems.Remove(taskListItem);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}