using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
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

        var taskListItem = await CheckIfTaskListItemExists(request.TaskListItemId);
        if (taskListItem == null)
            throw new NotFoundException("Task list item not found.");

        var taskList = await CheckIfTaskListExists(taskListItem.TaskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found.");

        if (!await CheckIfUserIsOwnerOrEditor(userId, taskList.Id))
            throw new UnauthorizedAccessException("You are not authorized to delete items from this task list.");


        if (!await DeleteTaskListItem(taskListItem))
            throw new ResourceModificationException("Task list item could not be deleted.");

        return new DeleteTaskListItemResponse()
        {
            Message = $"Item with id: {taskListItem.Id} has been deleted successfully.",
            TaskListId = taskListItem.TaskListId
        };
    }

    private async Task<Domain.Entities.TaskListItem?> CheckIfTaskListItemExists(int taskListItemId)
    {
        return await _context.TaskListItems
            .FirstOrDefaultAsync(tli => tli.Id == taskListItemId);
    }

    private async Task<Domain.Entities.TaskList?> CheckIfTaskListExists(int taskListId)
    {
        return await _context.TaskLists
            .FirstOrDefaultAsync(tl => tl.Id == taskListId);
    }

    private async Task<bool> CheckIfUserIsOwnerOrEditor(string userId, int taskListId)
    {
        return await _context.TaskListMembers
            .AnyAsync(q =>
                q.TaskListId == taskListId &&
                q.UserId == userId &&
                (q.Role == TaskListRole.Owner || q.Role == TaskListRole.Editor));
    }

    private async Task<bool> DeleteTaskListItem(Domain.Entities.TaskListItem taskListItem)
    {
        _context.TaskListItems.Remove(taskListItem);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}