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
    public string CategoryName { get; set; } = "No category assigned";
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
        var userId = userContextService.GetAuthenticatedUserId();
        var invitation = await ValidateInvitationAsync(request.Token);

        await EnsureUserIsNotAlreadyMemberAsync(userId, invitation.TaskListId);

        var (assignedCategoryId, categoryName) =
            await ProcessCategoryAsync(request.CategoryId, request.NewCategory, userId);

        if (assignedCategoryId.HasValue)
        {
            await AssignCategoryToUserAsync(invitation.TaskListId, userId, assignedCategoryId.Value);
        }

        await AcceptInvitationAndAddMemberAsync(invitation, userId);

        return new AcceptInviteCommandResponse
        {
            Message = "Invite accepted",
            TaskListId = invitation.TaskListId,
            CategoryName = categoryName ?? "No category assigned"
        };
    }

    private async Task<Domain.Entities.Invitation> ValidateInvitationAsync(string token)
    {
        var invitation = await invitationRepository.GetByTokenAsync(token)
                         ?? throw new NotFoundException("Invite has expired or has already been accepted");

        if (invitation.Status != InvitationStatus.Pending || invitation.ExpiresAt < DateTime.UtcNow)
        {
            throw new NotFoundException("Invite has expired or has already been accepted");
        }

        return invitation;
    }

    private async Task EnsureUserIsNotAlreadyMemberAsync(string userId, int taskListId)
    {
        if (await taskListMemberRepository.GetByUserAndTaskListAsync(userId, taskListId) != null)
        {
            throw new ConflictException("User is already part of this task list");
        }
    }

    private async Task<(int? AssignedCategoryId, string? CategoryName)> ProcessCategoryAsync(int? categoryId,
        CreateCategoryCommand? newCategory, string userId)
    {
        if (newCategory != null)
        {
            var category = new Category
            {
                Name = newCategory.Name,
                Color = newCategory.Color,
                Tag = newCategory.Tag,
                UserId = userId
            };
            await categoryRepository.AddAsync(category);
            return (category.Id, category.Name);
        }

        if (!categoryId.HasValue) return (null, null);

        var existingCategory = await categoryRepository.GetByIdAsync(userId, categoryId.Value);
        if (existingCategory == null) throw new NotFoundException("Category not found");

        return (existingCategory.Id, existingCategory.Name);
    }

    private async Task AssignCategoryToUserAsync(int taskListId, string userId, int categoryId)
    {
        if (await taskListRepository.GetByIdAsync(taskListId) == null)
        {
            throw new NotFoundException("Task list not found");
        }

        await userTaskListCategoryRepository.AddAsync(new UserTaskListCategory
        {
            UserId = userId,
            TaskListId = taskListId,
            CategoryId = categoryId
        });
    }

    private async Task AcceptInvitationAndAddMemberAsync(Domain.Entities.Invitation invitation, string userId)
    {
        invitation.Status = InvitationStatus.Accepted;
        await invitationRepository.UpdateAsync(invitation);

        await taskListMemberRepository.AddAsync(new TaskListMember
        {
            UserId = userId,
            TaskListId = invitation.TaskListId,
            Role = TaskListRole.Viewer
        });
    }
}