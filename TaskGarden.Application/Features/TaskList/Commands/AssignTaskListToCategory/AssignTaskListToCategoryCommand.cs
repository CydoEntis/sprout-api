// using AutoMapper;
// using FluentValidation;
// using MediatR;
// using TaskGarden.Application.Common.Contracts;
// using TaskGarden.Application.Common.Exceptions;
// using TaskGarden.Application.Features.Shared.Models;
// using TaskGarden.Application.Services.Contracts;
// using TaskGarden.Domain.Entities;
// using TaskGarden.Domain.Enums;
// using TaskGarden.Infrastructure.Projections;
//
// namespace TaskGarden.Application.Features.TaskList.Commands.AssignTaskListToCategory;
//
// public record AssignTaskListToCategoryCommand(int CategoryId)
//     : IRequest<AssignTaskListToCategoryResponse>;
//
// public class AssignTaskListToCategoryResponse : BaseResponse
// {
//     public int TaskListId { get; set; }
// }
//
// public class AssignTaskListToCategoryCommandHandler(
//     IUserContextService userContextService,
//     ITaskListRepository taskListRepository,
//     ICategoryRepository categoryRepository,
//     ITaskListMemberRepository taskListMemberRepository,
//     IValidator<AssignTaskListToCategoryCommand> validator,
//     IMapper mapper) : IRequestHandler<AssignTaskListToCategoryCommand, AssignTaskListToCategoryResponse>
// {
//     public async Task<AssignTaskListToCategoryResponse> Handle(AssignTaskListToCategoryCommand request, CancellationToken cancellationToken)
//     {
//         var userId = userContextService.GetUserId();
//         if (userId == null)
//             throw new UnauthorizedAccessException("User not authenticated");
//
//         var validationResult = await validator.ValidateAsync(request, cancellationToken);
//         if (!validationResult.IsValid)
//             throw new ValidationException(validationResult.Errors);
//
//         var category = await categoryRepository.GetByNameAsync(userId, request.CategoryName);
//
//         var taskList = mapper.Map<Domain.Entities.TaskList>(request);
//         taskList.CreatedById = userId;
//         taskList.CategoryId = category.Id;
//
//
//         var result = await taskListRepository.AddAsync(taskList);
//         var response = await AssignUserToTaskListAsync(userId, taskList.Id, TaskListRole.Owner);
//         if (!response)
//             throw new ResourceCreationException("Unable to assign user to task list.");
//
//         var taskListDetails = mapper.Map<TaskListPreview>(taskList);
//
//         return new AssignTaskListToCategoryResponse()
//             { Message = $"Task list created: {taskList.Id}", TaskListPreview = taskListDetails };
//     }
//
//     // Potentially move into its own class for reusability.
//     private async Task<bool> AssignUserToTaskListAsync(string userId, int taskListId, TaskListRole role)
//     {
//         try
//         {
//             var userTaskList = new TaskListMember
//             {
//                 UserId = userId,
//                 TaskListId = taskListId,
//                 Role = role
//             };
//
//             await taskListMemberRepository.AddAsync(userTaskList);
//             return true;
//         }
//         catch
//         {
//             return false;
//         }
//     }
// }