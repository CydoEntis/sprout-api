using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Enums;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.DeleteTaskList;

public record DeleteTaskListCommand(int TasklistId) : IRequest<DeleteTaskListResponse>;

public class DeleteTaskListResponse : BaseResponse;

public class DeleteTaskListCommandHandler : AuthRequiredHandler,
    IRequestHandler<DeleteTaskListCommand, DeleteTaskListResponse>
{
    private readonly AppDbContext _context;

    public DeleteTaskListCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
        httpContextAccessor)
    {
        _context = context;
    }

    public async Task<DeleteTaskListResponse> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var taskList = await _context.TaskLists.GetByIdAsync(request.TasklistId)
                       ?? throw new NotFoundException($"Task list with id {request.TasklistId} could not be found.");

        if (!await IsUserOwnerAsync(userId, taskList))
            throw new PermissionException("User does not have rights to delete this task list.");

        await DeleteTaskListTransactionAsync(taskList);

        return new DeleteTaskListResponse
        {
            Message = $"{taskList.Name} task list has been deleted successfully."
        };
    }

    private async Task<bool> IsUserOwnerAsync(string userId, Domain.Entities.TaskList taskList)
    {
        return await _context.TaskListMembers
            .AnyAsync(q => q.UserId == userId && q.TasklistId == taskList.Id && q.Role == TaskListRole.Owner);
    }

    private async Task DeleteTaskListTransactionAsync(Domain.Entities.TaskList taskList)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await DeleteTaskListItemsAsync(taskList.Id);
            await DeleteTaskListMembersAsync(taskList.Id);
            await DeleteTaskListAsync(taskList);

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
        var taskListItems = await _context.TaskListItems
            .Where(q => q.TasklistId == taskListId)
            .ToListAsync();

        if (taskListItems.Any())
            _context.TaskListItems.RemoveRange(taskListItems);
    }

    private async Task DeleteTaskListMembersAsync(int taskListId)
    {
        var taskListMembers = await _context.TaskListMembers
            .Where(q => q.TasklistId == taskListId)
            .ToListAsync();

        if (taskListMembers.Any())
            _context.TaskListMembers.RemoveRange(taskListMembers);
    }

    private async Task DeleteTaskListAsync(Domain.Entities.TaskList taskList)
    {
        _context.TaskLists.Remove(taskList);
        await _context.SaveChangesAsync();
    }
}