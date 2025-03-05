using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.TaskListItem.Commands.CreateTaskListItem;

public record CreateTaskListItemCommand(string Description, int TaskListId) : IRequest<CreateTaskListItemResponse>;

public class CreateTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class CreateTaskListItemCommandHandler(
    IUserContextService userContextService,
    ITaskListRepository taskListRepository,
    ITaskListItemRepository taskListItemRepository,
    IValidator<CreateTaskListItemCommand> validator,
    IMapper mapper) : IRequestHandler<CreateTaskListItemCommand, CreateTaskListItemResponse>
{
    public async Task<CreateTaskListItemResponse> Handle(CreateTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedException("Invalid user");
        
        var taskList = await taskListRepository.GetDetailsByIdAsync(request.TaskListId);
        if(taskList == null)
            throw new NotFoundException($"Task list with id: {request.TaskListId} does not exist");
        
        var taskListItem = mapper.Map<Domain.Entities.TaskListItem>(request);
        taskListItem.TaskListId = request.TaskListId;
        
        await taskListItemRepository.AddTaskListItemAsync(taskListItem);

        return new CreateTaskListItemResponse() { Message = $"Item added", TaskListId = 1 };
    }
}