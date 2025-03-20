using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Common.Models;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Infrastructure;

namespace TaskGarden.Application.Features.TaskListItem.Commands.ReorderTaskListItem;

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
        var taskList = GetTaskListByIdAsync(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException($"Task list with id {request.TaskListId} was not found");

        await ReorderTaskListItemsAsync(request.TaskListId, request.Items);

        return new ReorderTaskListItemResponse() { TaskListId = request.TaskListId, Message = "Item order updated." };
    }

    private async Task<Domain.Entities.TaskList?> GetTaskListByIdAsync(int taskListId)
    {
        return await _context.TaskLists.FirstOrDefaultAsync(q => q.Id == taskListId);
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