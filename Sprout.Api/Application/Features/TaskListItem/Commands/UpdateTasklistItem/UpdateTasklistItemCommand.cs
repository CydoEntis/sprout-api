using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Extensions;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Exceptions;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;

public record UpdateTasklistItemCommand(int Id, string Description, DateTime? DueDate)
    : IRequest<UpdateTaskListItemResponse>;

public class UpdateTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class UpdateTaskListItemCommandHandler : AuthRequiredHandler,
    IRequestHandler<UpdateTasklistItemCommand, UpdateTaskListItemResponse>
{
    private readonly AppDbContext _context;

    public UpdateTaskListItemCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
        httpContextAccessor)
    {
        _context = context;
    }

    public async Task<UpdateTaskListItemResponse> Handle(UpdateTasklistItemCommand request,
        CancellationToken cancellationToken)
    {
        var taskListItem = await _context.TaskListItems.GetByIdAsync(request.Id);
        if (taskListItem == null)
            throw new NotFoundException($"Task list item with id {request.Id} was not found");

        taskListItem.Description = request.Description;
        taskListItem.DueDate = request.DueDate; // <-- Update the DueDate if provided

        if (!await UpdateTaskListItemAsync(taskListItem))
            throw new ResourceModificationException($"Task list item with id: {taskListItem.Id} could not be updated.");

        return new UpdateTaskListItemResponse()
            { Message = $"Task list item with id {taskListItem.Id} updated", TaskListId = taskListItem.TasklistId };
    }

    private async Task<bool> UpdateTaskListItemAsync(Domain.Entities.TaskListItem taskListItem)
    {
        _context.Update(taskListItem);
        var changes = await _context.SaveChangesAsync();
        return changes > 0;
    }
}