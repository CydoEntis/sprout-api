using AutoMapper;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;

namespace TaskGarden.Application.Features.TaskListItem.Commands.ReorderTaskListItem;

public record ReorderTaskListItemCommand(int TaskListId, List<Domain.Entities.TaskListItem> Items)
    : IRequest<ReorderTaskListItemResponse>;

public class ReorderTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class ReorderTaskListItemCommandHandler(
    ITaskListItemRepository taskListItemRepository,
    IMapper mapper)
    : IRequestHandler<ReorderTaskListItemCommand, ReorderTaskListItemResponse>
{
    public async Task<ReorderTaskListItemResponse> Handle(ReorderTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var taskListItem = await taskListItemRepository.GetByIdAsync(request.TaskListId);
        if (taskListItem == null)
            throw new NotFoundException($"Task list with id {request.TaskListId} was not found");


        var taskListItems = mapper.Map<List<Domain.Entities.TaskListItem>>(taskListItem);

        await taskListItemRepository.ReorderTaskListItemsAsync(request.TaskListId, taskListItems);

        return new ReorderTaskListItemResponse() { TaskListId = request.TaskListId, Message = "Item order updated." };
    }
}