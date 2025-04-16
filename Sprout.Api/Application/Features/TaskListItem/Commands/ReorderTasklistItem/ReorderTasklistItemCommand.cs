using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Extensions;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Exceptions;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Features.TaskListItem.Commands.ReorderTaskListItem;

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
        var taskList = await _context.TaskLists.GetByIdAsync(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException($"Task list with id {request.TaskListId} was not found");

        await ReorderTaskListItemsAsync(request.TaskListId, request.Items);

        return new ReorderTaskListItemResponse() { TaskListId = request.TaskListId, Message = "Item order updated." };
    }

    private async Task ReorderTaskListItemsAsync(int taskListId, List<TasklistItemPosition> items)
    {
        var taskListItems = await _context.TaskListItems
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