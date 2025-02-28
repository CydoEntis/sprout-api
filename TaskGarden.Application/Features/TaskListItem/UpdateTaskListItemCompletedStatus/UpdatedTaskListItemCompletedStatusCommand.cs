using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.TaskListItem.UpdateTaskListItemCompletedStatus;

public record UpdateTaskListItemCompletedStatusCommand(int Id, bool IsCompleted)
    : IRequest<UpdateTaskListItemCompletedStatusResponse>;

public class UpdateTaskListItemCompletedStatusResponse : BaseResponse
{
    public int TaskListItemId { get; set; }
}

public class UpdateTaskListItemCompletedStatusCommandHandler(
    IUserContextService userContextService,
    ITaskListItemRepository taskListItemRepository,
    IValidator<UpdateTaskListItemCompletedStatusCommand> validator)
    : IRequestHandler<UpdateTaskListItemCompletedStatusCommand, UpdateTaskListItemCompletedStatusResponse>
{
    public async Task<UpdateTaskListItemCompletedStatusResponse> Handle(
        UpdateTaskListItemCompletedStatusCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedException("Invalid user");

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        var taskListItem = await taskListItemRepository.GetByIdAsync(request.Id);
        if (taskListItem == null)
            throw new NotFoundException($"Task list item with id {request.Id} was not found");

        taskListItem.IsCompleted = request.IsCompleted;
        taskListItem.CompletedById = request.IsCompleted ? userId : null;
        await taskListItemRepository.UpdateAsync(taskListItem);

        return new UpdateTaskListItemCompletedStatusResponse()
            { Message = $"Task list item with id {taskListItem.Id} status updated", TaskListItemId = taskListItem.Id };
    }
}