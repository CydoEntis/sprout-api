using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;

public record UpdateTasklistItemCommand(int Id, string Description) : IRequest<UpdateTaskListItemResponse>;

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