using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.ReorderTaskListItem;

public record ReorderTaskListItemCommand(int TaskListId, List<TaskListItemPosition> Items)
    : IRequest<ReorderTaskListItemResponse>;

public class ReorderTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class ReorderTaskListItemCommandHandler
    : AuthRequiredHandler, IRequestHandler<ReorderTaskListItemCommand, ReorderTaskListItemResponse>
{
    private readonly AppDbContext _context;

    public ReorderTaskListItemCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
        httpContextAccessor)
    {
        _context = context;
    }

    public async Task<ReorderTaskListItemResponse> Handle(ReorderTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var taskList = _context.TaskLists.GetByIdAsync(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException($"Task list with id {request.TaskListId} was not found");

        await ReorderTaskListItemsAsync(request.TaskListId, request.Items);

        return new ReorderTaskListItemResponse() { TaskListId = request.TaskListId, Message = "Item order updated." };
    }

    private async Task ReorderTaskListItemsAsync(int taskListId, List<TaskListItemPosition> items)
    {
        var taskListItems = await _context.TaskListItems
            .Where(i => i.TaskListId == taskListId)
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