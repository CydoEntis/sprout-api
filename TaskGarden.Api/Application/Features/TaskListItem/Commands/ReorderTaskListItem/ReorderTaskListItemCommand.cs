using AutoMapper;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Common.Models;
using TaskGarden.Application.Features.Shared.Models;

namespace TaskGarden.Application.Features.TaskListItem.Commands.ReorderTaskListItem;

public record ReorderTaskListItemCommand(int TaskListId, List<TaskListItemPosition> Items)
    : IRequest<ReorderTaskListItemResponse>;

public class ReorderTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class ReorderTaskListItemCommandHandler(
    ITaskListRepository taskListRepository,
    ITaskListItemRepository taskListItemRepository,
    IMapper mapper)
    : IRequestHandler<ReorderTaskListItemCommand, ReorderTaskListItemResponse>
{
    public async Task<ReorderTaskListItemResponse> Handle(ReorderTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var taskList = await taskListRepository.GetByIdAsync(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException($"Task list with id {request.TaskListId} was not found");

        await taskListItemRepository.ReorderTaskListItemsAsync(request.TaskListId, request.Items);

        return new ReorderTaskListItemResponse() { TaskListId = request.TaskListId, Message = "Item order updated." };
    }
}