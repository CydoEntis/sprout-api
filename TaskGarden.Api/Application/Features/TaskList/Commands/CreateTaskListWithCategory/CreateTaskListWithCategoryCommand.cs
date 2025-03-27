using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskListWithCategory;

public record CreateTaskListWithCategoryCommand(
    string CategoryName,
    string CategoryTag,
    string CategoryColor,
    string TaskListName,
    string TaskListDescription)
    : IRequest<CreateTaskListWithCategoryResponse>;

public class CreateTaskListWithCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
    public int TaskListId { get; set; }
}

public class CreateTaskListWithCategoryCommandHandler : AuthRequiredHandler,
    IRequestHandler<CreateTaskListWithCategoryCommand, CreateTaskListWithCategoryResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<CreateTaskListWithCategoryCommand> _validator;
    private readonly IMapper _mapper;

    public CreateTaskListWithCategoryCommandHandler(
        IHttpContextAccessor httpContextAccessor,
        AppDbContext context,
        IValidator<CreateTaskListWithCategoryCommand> validator,
        IMapper mapper
    ) : base(httpContextAccessor)
    {
        _context = context;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CreateTaskListWithCategoryResponse> Handle(CreateTaskListWithCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId() ?? throw new UnauthorizedException("Invalid user");

        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if (await _context.Categories.CategoryExistsAsync(request.CategoryName, userId))
                throw new ConflictException($"Category with name {request.CategoryName} already exists.");

            var category = new Category
            {
                Name = request.CategoryName,
                Tag = request.CategoryTag,
                Color = request.CategoryColor,
                UserId = userId
            };

            var createdCategory = await _context.CreateCategoryAsync(category);
            if (createdCategory == null)
                throw new ResourceCreationException("Category could not be created.");

            var taskList = new Domain.Entities.TaskList
            {
                Name = request.TaskListName,
                Description = request.TaskListDescription,
                CreatedById = userId,
            };

            var createdTaskList = await _context.TaskLists.AddAsync(taskList, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken); 

            if (createdTaskList == null)
                throw new ResourceCreationException("Task list could not be created.");

            var userTaskListCategory = new UserTaskListCategory
            {
                TaskListId = createdTaskList.Entity.Id,
                CategoryId = createdCategory.Id,
                UserId = userId
            };

            _context.UserTaskListCategories.Add(userTaskListCategory);

            await _context.SaveChangesAsync(cancellationToken); 
            await transaction.CommitAsync(cancellationToken);

            return new CreateTaskListWithCategoryResponse
            {
                CategoryId = createdCategory.Id,
                TaskListId = createdTaskList.Entity.Id,
                Message = "Category and Task List created successfully."
            };
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}