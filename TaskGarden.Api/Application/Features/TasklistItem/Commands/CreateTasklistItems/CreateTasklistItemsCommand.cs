using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItems;

public class CreateTasklistItemsCommand : IRequest<CreateTaskListItemsResponse>
{
    public List<CreateTasklistItemCommand> TaskListItems { get; set; }
}

public class CreateTaskListItemsResponse : BaseResponse
{
    public List<TasklistItemDetail> TaskListItemDetails { get; set; }
}

public class
    CreateTaskListItemsCommandHandler : IRequestHandler<CreateTasklistItemsCommand, CreateTaskListItemsResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<CreateTasklistItemCommand> _validator;
    private readonly IMapper _mapper;

    public CreateTaskListItemsCommandHandler(AppDbContext context, IValidator<CreateTasklistItemCommand> validator,
        IMapper mapper)
    {
        _context = context;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CreateTaskListItemsResponse> Handle(CreateTasklistItemsCommand request,
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
            taskListItem.TasklistId = item.TaskListId;
            taskListItems.Add(taskListItem);
        }

        await _context.TaskListItems.AddRangeAsync(taskListItems);
        await _context.SaveChangesAsync();

        var taskListItemDetails = _mapper.Map<List<TasklistItemDetail>>(taskListItems);

        return new CreateTaskListItemsResponse
        {
            Message = "Items added",
            TaskListItemDetails = taskListItemDetails
        };
    }
}