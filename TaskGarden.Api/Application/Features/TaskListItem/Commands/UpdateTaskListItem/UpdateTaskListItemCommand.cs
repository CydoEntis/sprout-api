using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Infrastructure;

namespace TaskGarden.Application.Features.TaskListItem.Commands.UpdateTaskListItem;

public record UpdateTaskListItemCommand(int Id, string Description) : IRequest<UpdateTaskListItemResponse>;

public class UpdateTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class UpdateTaskListItemCommandHandler : AuthRequiredHandler,
    IRequestHandler<UpdateTaskListItemCommand, UpdateTaskListItemResponse>
{
    private readonly AppDbContext _context;

    public UpdateTaskListItemCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
        httpContextAccessor)
    {
        _context = context;
    }

    public async Task<UpdateTaskListItemResponse> Handle(UpdateTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var taskListItem = await GetTaskListItemByIdAsync(request.Id);
        if (taskListItem == null)
            throw new NotFoundException($"Task list item with id {request.Id} was not found");

        taskListItem.Description = request.Description;
        if (!await UpdateTaskListItemAsync(taskListItem))
            throw new ResourceModificationException($"Task list item with id: {taskListItem.Id} could not be updated.");

        return new UpdateTaskListItemResponse()
            { Message = $"Task list item with id {taskListItem.Id} updated", TaskListId = taskListItem.TaskListId };
    }

    private async Task<Domain.Entities.TaskListItem?> GetTaskListItemByIdAsync(int taskListItemId)
    {
        return await _context.TaskListItems.FirstOrDefaultAsync(q => q.Id == taskListItemId);
    }

    private async Task<bool> UpdateTaskListItemAsync(Domain.Entities.TaskListItem taskListItem)
    {
        _context.Update(taskListItem);
        var changes = await _context.SaveChangesAsync();
        return changes > 0;
    }
}