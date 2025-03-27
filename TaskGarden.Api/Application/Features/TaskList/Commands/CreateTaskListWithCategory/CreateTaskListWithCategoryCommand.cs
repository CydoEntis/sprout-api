using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskListWithCategory;

public record CreateTaskListWithCategoryCommand(
    int? CategoryId,
    string? CategoryName,
    string? CategoryTag,
    string? CategoryColor,
    string TaskListName,
    string TaskListDescription
) : IRequest<CreateTaskListWithCategoryResponse>;

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
            var category = await GetCategoryOrCreateAsync(request, userId, cancellationToken);

            var createdTaskList = await CreateTaskListAsync(request, userId, cancellationToken);

            if (!await _context.AssignCategoryAndTaskListAsync(userId, createdTaskList.Id, category.Id))
            {
                throw new ResourceCreationException("Could not assign category and task list to user.");
            }

            if (!await _context.AssignUserAsync(userId, createdTaskList.Id))
            {
                throw new ResourceCreationException("Could not assign user to task list.");
            }


            await transaction.CommitAsync(cancellationToken);

            return new CreateTaskListWithCategoryResponse
            {
                CategoryId = category.Id,
                TaskListId = createdTaskList.Id,
                Message = category.Id == request.CategoryId
                    ? "Task List created and associated with existing category."
                    : "Category and Task List created successfully."
            };
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    private async Task<Category> GetCategoryOrCreateAsync(CreateTaskListWithCategoryCommand request, string userId,
        CancellationToken cancellationToken)
    {
        if (request.CategoryId is not null)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == request.CategoryId && c.UserId == userId, cancellationToken);

            if (category == null)
                throw new NotFoundException("Category not found.");

            return category;
        }

        return await CreateCategoryAsync(request, userId);
    }

    private async Task<Category> CreateCategoryAsync(CreateTaskListWithCategoryCommand request, string userId)
    {
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

        return createdCategory;
    }

    private async Task<Domain.Entities.TaskList> CreateTaskListAsync(CreateTaskListWithCategoryCommand request,
        string userId, CancellationToken cancellationToken)
    {
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

        return createdTaskList.Entity;
    }
}