using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Repositories;

namespace TaskGarden.Application.Features.Invitation.Commands.AcceptInvite;

public record AcceptInviteCommand(string Token, int? CategoryId, CreateCategoryCommand? NewCategory)
    : IRequest<AcceptInviteCommandResponse>;

public class AcceptInviteCommandResponse : BaseResponse
{
    public string CategoryName { get; set; }
    public int TaskListId { get; set; }
}

public class AcceptInviteCommandHandler(
    IInvitationRepository invitationRepository,
    IUserContextService userContextService,
    ITaskListMemberRepository taskListMemberRepository,
    ICategoryRepository categoryRepository,
    ITaskListRepository taskListRepository,
    IUserTaskListCategoryRepository userTaskListCategoryRepository)
    : IRequestHandler<AcceptInviteCommand, AcceptInviteCommandResponse>
{
    public async Task<AcceptInviteCommandResponse> Handle(AcceptInviteCommand request,
        CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        var invitation = await invitationRepository.GetByTokenAsync(request.Token);

        if (invitation == null || invitation.Status != InvitationStatus.Pending ||
            invitation.ExpiresAt < DateTime.UtcNow)
            throw new NotFoundException("Invite has expired, or has already been accepted");

        var taskListId = invitation.TaskListId;

        var existingMember = await taskListMemberRepository.GetByUserAndTaskListAsync(userId, taskListId);
        if (existingMember != null)
            throw new ConflictException("User is already part of this task list");

        int? assignedCategoryId = request.CategoryId;
        string? categoryName = null;

        if (request.NewCategory != null)
        {
            var newCategory = new Category
            {
                Name = request.NewCategory.Name,
                Color = request.NewCategory.Color,
                Tag = request.NewCategory.Tag,
                UserId = userId
            };

            await categoryRepository.AddAsync(newCategory);
            assignedCategoryId = newCategory.Id;
            categoryName = newCategory.Name; // Set category name from newly created category
        }
        else if (assignedCategoryId.HasValue)
        {
            var existingCategory = await categoryRepository.GetByIdAsync(assignedCategoryId.Value);
            if (existingCategory == null)
                throw new NotFoundException("Category not found");

            categoryName = existingCategory.Name; // Set category name from existing category
        }

        if (assignedCategoryId.HasValue)
        {
            var taskList = await taskListRepository.GetByIdAsync(taskListId);
            if (taskList == null)
                throw new NotFoundException("Task list not found");

            var userTaskListCategory = new UserTaskListCategory
            {
                UserId = userId,
                TaskListId = taskListId,
                CategoryId = assignedCategoryId.Value
            };

            await userTaskListCategoryRepository.AddAsync(userTaskListCategory);
        }

        invitation.Status = InvitationStatus.Accepted;
        await invitationRepository.UpdateAsync(invitation);

        var newMember = new TaskListMember
        {
            UserId = userId,
            TaskListId = taskListId,
            Role = TaskListRole.Viewer
        };
        await taskListMemberRepository.AddAsync(newMember);

        return new AcceptInviteCommandResponse
        {
            Message = "Invite accepted",
            TaskListId = taskListId,
            CategoryName = categoryName ?? "No category assigned"
        };
    }
}