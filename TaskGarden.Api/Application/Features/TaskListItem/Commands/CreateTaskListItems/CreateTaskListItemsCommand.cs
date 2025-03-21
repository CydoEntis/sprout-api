using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItems;

public class CreateTaskListItemsCommand : IRequest<CreateTaskListItemsResponse>
{
    public List<CreateTaskListItemCommand> TaskListItems { get; set; }
}

public class CreateTaskListItemsResponse : BaseResponse
{
    public List<TaskListItemDetail> TaskListItemDetails { get; set; }
}

public class
    CreateTaskListItemsCommandHandler : IRequestHandler<CreateTaskListItemsCommand, CreateTaskListItemsResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<CreateTaskListItemCommand> _validator;
    private readonly IMapper _mapper;

    public CreateTaskListItemsCommandHandler(AppDbContext context, IValidator<CreateTaskListItemCommand> validator,
        IMapper mapper)
    {
        _context = context;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CreateTaskListItemsResponse> Handle(CreateTaskListItemsCommand request,
        CancellationToken cancellationToken)
    {
        var validationResults = new List<ValidationResult>();

        foreach (var item in request.TaskListItems)
        {
            var validationResult = await _validator.ValidateAsync(item, cancellationToken);
            validationResults.Add(validationResult);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
        }

        var taskListItems = new List<Domain.Entities.TaskListItem>();
        foreach (var item in request.TaskListItems)
        {
            var taskListItem = _mapper.Map<Domain.Entities.TaskListItem>(item);
            taskListItem.TaskListId = item.TaskListId;
            taskListItems.Add(taskListItem);
        }

        await _context.TaskListItems.AddRangeAsync(taskListItems);
        await _context.SaveChangesAsync();

        var taskListItemDetails = _mapper.Map<List<TaskListItemDetail>>(taskListItems);

        return new CreateTaskListItemsResponse
        {
            Message = "Items added",
            TaskListItemDetails = taskListItemDetails
        };
    }
}