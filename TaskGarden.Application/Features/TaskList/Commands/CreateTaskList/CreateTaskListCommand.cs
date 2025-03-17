using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Application.Features.TaskList.Commands.CreateTaskList;

public record CreateTaskListCommand(string Name, string Description, string CategoryName)
    : IRequest<CreateTaskListResponse>;

public class CreateTaskListResponse : BaseResponse
{
    public TaskListPreview TaskListPreview { get; set; }
}

public class CreateTaskListCommandHandler(
    IUserContextService userContextService,
    ITaskListRepository taskListRepository,
    ICategoryRepository categoryRepository,
    ITaskListMemberRepository taskListMemberRepository,
    IMapper mapper,
    IValidationService validationService,
    IUserTaskListCategoryRepository userTaskListCategoryRepository
) : IRequestHandler<CreateTaskListCommand, CreateTaskListResponse>
{
    public async Task<CreateTaskListResponse> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetAuthenticatedUserId();

        await validationService.ValidateRequestAsync(request, cancellationToken);

        await CheckIfUserIsOwnerAsync(userId);

        var category = await GetCategoryAsync(userId, request.CategoryName);
        var taskList = await CreateTaskListAsync(request, userId);
        await AssignCategoryToTaskListAsync(userId, category, taskList);
        await AssignUserToTaskListAsync(userId, taskList);

        var taskListPreview = mapper.Map<TaskListPreview>(taskList);

        return new CreateTaskListResponse
        {
            Message = $"Task list created: {taskList.Id}",
            TaskListPreview = taskListPreview
        };
    }

    private async Task CheckIfUserIsOwnerAsync(string userId)
    {
        var member = await taskListMemberRepository.GetMemberByUserIdAsync(userId);
        if (member == null || member.Role != TaskListRole.Owner)
        {
            throw new UnauthorizedAccessException("Only owners can create task lists.");
        }
    }

    private async Task<Category> GetCategoryAsync(string userId, string categoryName)
    {
        var category = await categoryRepository.GetByNameAsync(userId, categoryName);
        if (category == null)
            throw new NotFoundException($"Category {categoryName} not found.");
        return category;
    }

    private async Task<Domain.Entities.TaskList> CreateTaskListAsync(CreateTaskListCommand request, string userId)
    {
        var taskList = mapper.Map<Domain.Entities.TaskList>(request);
        taskList.CreatedById = userId;
        return await taskListRepository.AddAsync(taskList);
    }

    private async Task AssignCategoryToTaskListAsync(string userId, Category category,
        Domain.Entities.TaskList taskList)
    {
        var userTaskListCategory = new UserTaskListCategory
        {
            UserId = userId,
            TaskListId = taskList.Id,
            CategoryId = category.Id
        };
        await userTaskListCategoryRepository.AddAsync(userTaskListCategory);
    }

    private async Task AssignUserToTaskListAsync(string userId, Domain.Entities.TaskList taskList)
    {
        var result = await taskListMemberRepository.AddAsync(new TaskListMember
        {
            UserId = userId,
            TaskListId = taskList.Id,
            Role = TaskListRole.Owner
        });

        if (result == null)
            throw new ResourceCreationException("Unable to assign user to task list.");
    }
}