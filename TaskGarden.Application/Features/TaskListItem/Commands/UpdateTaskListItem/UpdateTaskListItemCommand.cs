using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.TaskListItem.Commands.UpdateTaskListItem;

public record UpdateTaskListItemCommand(int Id, string Description) : IRequest<UpdateTaskListItemResponse>;

public class UpdateTaskListItemResponse : BaseResponse
{
    public int TaskListItemId { get; set; }
}

public class UpdateTaskListItemCommandHandler(
    ITaskListItemRepository taskListItemRepository,
    IMapper mapper) : IRequestHandler<UpdateTaskListItemCommand, UpdateTaskListItemResponse>
{
    public async Task<UpdateTaskListItemResponse> Handle(UpdateTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var taskListItem = await taskListItemRepository.GetByIdAsync(request.Id);
        if (taskListItem == null)
            throw new NotFoundException($"Task list item with id {request.Id} was not found");

        taskListItem.Description = request.Description;
        await taskListItemRepository.UpdateAsync(taskListItem);

        return new UpdateTaskListItemResponse()
            { Message = $"Task list item with id {taskListItem.Id} updated", TaskListItemId = taskListItem.Id };
    }
}