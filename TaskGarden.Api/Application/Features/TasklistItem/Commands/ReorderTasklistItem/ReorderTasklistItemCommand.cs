using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.ReorderTaskListItem;

public record ReorderTasklistItemCommand(int TaskListId, List<TasklistItemPosition> Items)
    : IRequest<ReorderTaskListItemResponse>;

public class ReorderTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class ReorderTaskListItemCommandHandler
    : AuthRequiredHandler, IRequestHandler<ReorderTasklistItemCommand, ReorderTaskListItemResponse>
{
    private readonly AppDbContext _context;

    public ReorderTaskListItemCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
        httpContextAccessor)
    {
        _context = context;
    }

    public async Task<ReorderTaskListItemResponse> Handle(ReorderTasklistItemCommand request,
        CancellationToken cancellationToken)
    {
        var taskList = await _context.Tasklists.GetByIdAsync(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException($"Task list with id {request.TaskListId} was not found");

        await ReorderTaskListItemsAsync(request.TaskListId, request.Items);

        return new ReorderTaskListItemResponse() { TaskListId = request.TaskListId, Message = "Item order updated." };
    }

    private async Task ReorderTaskListItemsAsync(int taskListId, List<TasklistItemPosition> items)
    {
        var taskListItems = await _context.TasklistItems
            .Where(i => i.TasklistId == taskListId)
            .ToListAsync();

        foreach (var item in items)
        {
            var taskItem = taskListItems.FirstOrDefault(i => i.Id == item.Id);
            if (taskItem != null)
            {
                taskItem.Position = item.Position;
            }
        }

        await _context.SaveChangesAsync();
    }
}