using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;

public record CreateTasklistItemCommand(string Description, int TaskListId) : IRequest<CreateTaskListItemResponse>;

public class CreateTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
    public TasklistItemDetail TasklistItemDetail { get; set; }
}

public class CreateTaskListItemCommandHandler :
    IRequestHandler<CreateTasklistItemCommand, CreateTaskListItemResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<CreateTasklistItemCommand> _validator;
    private readonly IMapper _mapper;

    public CreateTaskListItemCommandHandler(AppDbContext context,
        IValidator<CreateTasklistItemCommand> validator, IMapper mapper)
    {
        _context = context;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CreateTaskListItemResponse> Handle(CreateTasklistItemCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var taskListExists = await _context.Tasklists.ExistsAsync(request.TaskListId);
        if (!taskListExists)
            throw new NotFoundException("TaskList");

        var taskListItem = _mapper.Map<Domain.Entities.TasklistItem>(request);
        taskListItem.TaskListId = request.TaskListId;

        var createdTaskListItem = await CreateTaskListItemAsync(taskListItem, request.TaskListId);

        var taskListItemDetail = _mapper.Map<TasklistItemDetail>(createdTaskListItem);

        return new CreateTaskListItemResponse()
            { Message = $"Item added", TaskListId = request.TaskListId, TasklistItemDetail = taskListItemDetail };
    }


    private async Task<Domain.Entities.TasklistItem> CreateTaskListItemAsync(Domain.Entities.TasklistItem tasklistItem,
        int taskListId)
    {
        tasklistItem.TaskListId = taskListId;
        await _context.TaskListItems.AddAsync(tasklistItem);
        await _context.SaveChangesAsync();
        return tasklistItem;
    }
}