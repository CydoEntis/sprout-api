using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.TaskListItem.Commands;

public record CreateTaskListItemCommand(string Description, int TaskListId)
    : IRequest<CreateTaskListItemResponse>;

public class CreateTaskListItemResponse : BaseResponse
{
    public int TaskListItemId { get; set; }
}

public class CreateTaskListItemCommandHandler(
    IUserContextService userContextService,
    ITaskListRepository taskListRepository,
    ITaskListItemRepository taskListItemRepository,
    // IValidator<CreateTaskListItemCommand> validator,
    IMapper mapper) : IRequestHandler<CreateTaskListItemCommand, CreateTaskListItemResponse>
{
    public async Task<CreateTaskListItemResponse> Handle(CreateTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        // var validationResult = await validator.ValidateAsync(request, cancellationToken);
        // if (!validationResult.IsValid)
        //     throw new ValidationException(validationResult.Errors);

        var taskList = await taskListRepository.GetByIdAsync(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException($"Task list with id {request.TaskListId} was not found");

        var taskListItem = mapper.Map<Domain.Entities.TaskListItem>(request);
        taskListItem.TaskListId = taskList.Id;

        // var taskList = mapper.Map<Domain.Entities.TaskList>(request);
        // taskList.CreatedById = userId;
        // taskList.CategoryId = category.Id;


        await taskListItemRepository.AddAsync(taskListItem);


        return new CreateTaskListItemResponse()
            { Message = $"Task list created: {taskList.Id}", TaskListItemId = taskListItem.Id };
    }
}