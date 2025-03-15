using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Repositories;

namespace TaskGarden.Application.Features.Invitation.Commands.AcceptInvite;


public record AcceptInviteCommand(string Token, int? CategoryId, CreateCategoryCommand? NewCategory) : IRequest<bool>;

public class AcceptInviteCommandHandler(
    IInvitationRepository invitationRepository,
    IUserContextService userContextService,
    ITaskListMemberRepository taskListMemberRepository,
    ICategoryRepository categoryRepository,
    ITaskListRepository taskListRepository)
    : IRequestHandler<AcceptInviteCommand, bool>
{
    public async Task<bool> Handle(AcceptInviteCommand request, CancellationToken cancellationToken)
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

        // Handle category assignment
        int? assignedCategoryId = request.CategoryId;

        if (request.NewCategory != null)
        {
            // Create a new category
            var newCategory = new Category
            {
                Name = request.NewCategory.Name,
                Color = request.NewCategory.Color,
                Tag = request.NewCategory.Tag,
                UserId = userId
            };

            await categoryRepository.AddAsync(newCategory);
            assignedCategoryId = newCategory.Id;
        }

        if (assignedCategoryId.HasValue)
        {
            var taskList = await taskListRepository.GetByIdAsync(taskListId);
            if (taskList == null)
                throw new NotFoundException("Task list not found");

            taskList.CategoryId = assignedCategoryId.Value;
            await taskListRepository.UpdateAsync(taskList);
        }

        // Accept the invite
        invitation.Status = InvitationStatus.Accepted;
        await invitationRepository.UpdateAsync(invitation);

        // Add user as a member
        var newMember = new TaskListMember
        {
            UserId = userId,
            TaskListId = taskListId,
            Role = TaskListRole.Viewer
        };
        await taskListMemberRepository.AddAsync(newMember);

        return true;
    }
}