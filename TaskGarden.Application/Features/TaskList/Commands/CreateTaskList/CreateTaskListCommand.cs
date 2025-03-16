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
    IUserTaskListCategoryRepository userTaskListCategoryRepository,
    IValidator<CreateTaskListCommand> validator,
    IMapper mapper) : IRequestHandler<CreateTaskListCommand, CreateTaskListResponse>
{
    public async Task<CreateTaskListResponse> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetAuthenticatedUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var category = await categoryRepository.GetByNameAsync(userId, request.CategoryName);

        var taskList = mapper.Map<Domain.Entities.TaskList>(request);
        taskList.CreatedById = userId;

        var createdTaskList = await taskListRepository.AddAsync(taskList);

        var userTaskListCategory = new UserTaskListCategory
        {
            UserId = userId,
            TaskListId = createdTaskList.Id,
            CategoryId = category.Id
        };

        await userTaskListCategoryRepository.AddAsync(userTaskListCategory);

        var result = await taskListMemberRepository.AddAsync(new TaskListMember
        {
            UserId = userId,
            TaskListId = createdTaskList.Id,
            Role = TaskListRole.Owner
        });

        if (result == null)
            throw new ResourceCreationException("Unable to assign user to task list.");

        var taskListDetails = mapper.Map<TaskListPreview>(createdTaskList);

        return new CreateTaskListResponse()
        {
            Message = $"Task list created: {createdTaskList.Id}",
            TaskListPreview = taskListDetails
        };
    }
}