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
        var invitation = await GetInvitationAsync(request.Token);
        var taskListId = invitation.TaskListId;

        await EnsureUserIsNotAMemberOfTaskListAsync(userId, taskListId);

        var categoryInfo = await GetCategoryAsync(request.CategoryId, request.NewCategory, userId);

        if (categoryInfo.AssignedCategoryId.HasValue)
        {
            await AssignCategoryToUserAsync(taskListId, userId, categoryInfo.AssignedCategoryId.Value);
        }

        await AcceptInvitationAsync(invitation);

        await AddNewMemberToTaskListAsync(userId, taskListId);

        return new AcceptInviteCommandResponse
        {
            Message = "Invite accepted",
            TaskListId = taskListId,
            CategoryName = categoryInfo.CategoryName ?? "No category assigned"
        };
    }

    private async Task<Domain.Entities.Invitation> GetInvitationAsync(string token)
    {
        var invitation = await invitationRepository.GetByTokenAsync(token);
        if (invitation == null || invitation.Status != InvitationStatus.Pending ||
            invitation.ExpiresAt < DateTime.UtcNow)
            throw new NotFoundException("Invite has expired, or has already been accepted");
        return invitation;
    }

    private async Task EnsureUserIsNotAMemberOfTaskListAsync(string userId, int taskListId)
    {
        var existingMember = await taskListMemberRepository.GetByUserAndTaskListAsync(userId, taskListId);
        if (existingMember != null)
            throw new ConflictException("User is already part of this task list");
    }

    private async Task<(int? AssignedCategoryId, string? CategoryName)> GetCategoryAsync(int? categoryId,
        CreateCategoryCommand? newCategory, string userId)
    {
        if (newCategory != null)
        {
            return await CreateNewCategoryAsync(newCategory, userId);
        }

        return await GetExistingCategoryAsync(categoryId);
    }

    private async Task<(int? AssignedCategoryId, string? CategoryName)> CreateNewCategoryAsync(
        CreateCategoryCommand newCategory, string userId)
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

    private async Task<(int? AssignedCategoryId, string? CategoryName)> GetExistingCategoryAsync(int? categoryId)
    {
        if (!categoryId.HasValue)
            return (null, null);

        var category = await categoryRepository.GetByIdAsync(categoryId.Value);
        if (category == null)
            throw new NotFoundException("Category not found");

        return (category.Id, category.Name);
    }

    private async Task AssignCategoryToUserAsync(int taskListId, string userId, int categoryId)
    {
        var taskList = await taskListRepository.GetByIdAsync(taskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found");

        var userTaskListCategory = new UserTaskListCategory
        {
            UserId = userId,
            TaskListId = taskListId,
            CategoryId = categoryId
        };

        await userTaskListCategoryRepository.AddAsync(userTaskListCategory);
    }

    private async Task AcceptInvitationAsync(Domain.Entities.Invitation invitation)
    {
        invitation.Status = InvitationStatus.Accepted;
        await invitationRepository.UpdateAsync(invitation);
    }

    private async Task AddNewMemberToTaskListAsync(string userId, int taskListId)
    {
        var newMember = new TaskListMember
        {
            UserId = userId,
            TaskListId = taskListId,
            Role = TaskListRole.Viewer
        };
        await taskListMemberRepository.AddAsync(newMember);
    }
}