using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Infrastructure;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;

public record CreateTaskListItemCommand(string Description, int TaskListId) : IRequest<CreateTaskListItemResponse>;

public class CreateTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
    public TaskListItemDetail TaskListItemDetail { get; set; }
}

public class CreateTaskListItemCommandHandler :
    IRequestHandler<CreateTaskListItemCommand, CreateTaskListItemResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<CreateTaskListItemCommand> _validator;
    private readonly IMapper _mapper;

    public CreateTaskListItemCommandHandler(AppDbContext context,
        IValidator<CreateTaskListItemCommand> validator, IMapper mapper)
    {
        _context = context;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CreateTaskListItemResponse> Handle(CreateTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var taskListExists = await CheckIfTaskListExists(request.TaskListId);
        if (!taskListExists)
            throw new NotFoundException("TaskList");

        var taskListItem = _mapper.Map<Domain.Entities.TaskListItem>(request);
        taskListItem.TaskListId = request.TaskListId;

        var createdTaskListItem = await CreateTaskListItemAsync(taskListItem, request.TaskListId);

        var taskListItemDetail = _mapper.Map<TaskListItemDetail>(createdTaskListItem);

        return new CreateTaskListItemResponse()
            { Message = $"Item added", TaskListId = request.TaskListId, TaskListItemDetail = taskListItemDetail };
    }

    private async Task<bool> CheckIfTaskListExists(int taskListId)
    {
        return await _context.TaskLists.AnyAsync(q => q.Id == taskListId);
    }


    private async Task<Domain.Entities.TaskListItem> CreateTaskListItemAsync(Domain.Entities.TaskListItem taskListItem,
        int taskListId)
    {
        taskListItem.TaskListId = taskListId;
        await _context.TaskListItems.AddAsync(taskListItem);
        await _context.SaveChangesAsync();
        return taskListItem;
    }
}