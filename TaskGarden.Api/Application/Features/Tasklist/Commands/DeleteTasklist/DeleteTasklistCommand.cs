using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Enums;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.DeleteTaskList;

public record DeleteTasklistCommand(int TasklistId) : IRequest<DeleteTaskListResponse>;

public class DeleteTaskListResponse : BaseResponse;

public class DeleteTaskListCommandHandler : AuthRequiredHandler,
    IRequestHandler<DeleteTasklistCommand, DeleteTaskListResponse>
{
    private readonly AppDbContext _context;

    public DeleteTaskListCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
        httpContextAccessor)
    {
        _context = context;
    }

    public async Task<DeleteTaskListResponse> Handle(DeleteTasklistCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var taskList = await _context.Tasklists.GetByIdAsync(request.TasklistId)
                       ?? throw new NotFoundException($"Task list with id {request.TasklistId} could not be found.");

        if (!await IsUserOwnerAsync(userId, taskList))
            throw new PermissionException("User does not have rights to delete this task list.");

        await DeleteTaskListTransactionAsync(taskList);

        return new DeleteTaskListResponse
        {
            Message = $"{taskList.Name} task list has been deleted successfully."
        };
    }

    private async Task<bool> IsUserOwnerAsync(string userId, Domain.Entities.Tasklist tasklist)
    {
        return await _context.TasklistMembers
            .AnyAsync(q => q.UserId == userId && q.TasklistId == tasklist.Id && q.Role == TaskListRole.Owner);
    }

    private async Task DeleteTaskListTransactionAsync(Domain.Entities.Tasklist tasklist)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await DeleteTaskListItemsAsync(tasklist.Id);
            await DeleteTaskListMembersAsync(tasklist.Id);
            await DeleteTaskListAsync(tasklist);

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw new ResourceModificationException("Failed to delete task list and dependencies.");
        }
    }

    private async Task DeleteTaskListItemsAsync(int taskListId)
    {
        var taskListItems = await _context.TasklistItems
            .Where(q => q.TasklistId == taskListId)
            .ToListAsync();

        if (taskListItems.Any())
            _context.TasklistItems.RemoveRange(taskListItems);
    }

    private async Task DeleteTaskListMembersAsync(int taskListId)
    {
        var taskListMembers = await _context.TasklistMembers
            .Where(q => q.TasklistId == taskListId)
            .ToListAsync();

        if (taskListMembers.Any())
            _context.TasklistMembers.RemoveRange(taskListMembers);
    }

    private async Task DeleteTaskListAsync(Domain.Entities.Tasklist tasklist)
    {
        _context.Tasklists.Remove(tasklist);
        await _context.SaveChangesAsync();
    }
}