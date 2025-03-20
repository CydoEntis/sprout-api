using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Invitation.Commands.AcceptInvite;

public record AcceptInviteCommand(string Token, int? CategoryId, NewCategoryCommand? NewCategory)
    : IRequest<AcceptInviteCommandResponse>;

public record NewCategoryCommand(string Name, string Tag, string Color);

public class AcceptInviteCommandResponse : BaseResponse
{
    public string CategoryName { get; set; } = "No category assigned";
    public int TaskListId { get; set; }
}

public class AcceptInviteCommandHandler
    : AuthRequiredHandler, IRequestHandler<AcceptInviteCommand, AcceptInviteCommandResponse>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AcceptInviteCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IMapper mapper) : base(httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AcceptInviteCommandResponse> Handle(AcceptInviteCommand request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();
        var invitation = await GetInvitationAsync(request.Token);

        if (invitation is null || invitation.Status != InvitationStatus.Pending ||
            invitation.ExpiresAt < DateTime.UtcNow)
            throw new NotFoundException("Invite has expired, has already been accepted, or does not exist");

        if (await IsUserAMemberOfTaskListAsync(userId, invitation.TaskListId))
            throw new ConflictException("User is already part of this task list");

        Category? category = null;

        if (request.NewCategory is not null)
        {
            var newCategory = _mapper.Map<Category>(request.NewCategory);
            category = await CreateCategoryAsync(newCategory, userId);
        }
        else if (request.CategoryId.HasValue)
        {
            category = await GetCategoryByIdAsync(request.CategoryId.Value)
                       ?? throw new NotFoundException("Category not found.");
        }

        if (category is null)
            throw new NotFoundException("Category not found.");

        var categoryAssigned = await AssignCategoryAndTaskListToUserAsync(userId, invitation.TaskListId, category.Id);
        if (!categoryAssigned)
            throw new ApplicationException("Failed to assign category to the user.");

        var inviteAccepted = await AcceptInviteAsync(invitation);
        if (!inviteAccepted)
            throw new ApplicationException("Failed to update invitation status.");

        var addedToTaskList = await AddUserToTaskListAsync(userId, invitation.TaskListId);
        if (!addedToTaskList)
            throw new ApplicationException("Failed to add user to the task list.");


        return new AcceptInviteCommandResponse
        {
            Message = "Invite accepted",
            TaskListId = invitation.TaskListId,
            CategoryName = category?.Name ?? "No category assigned"
        };
    }

    private async Task<Domain.Entities.Invitation?> GetInvitationAsync(string token)
    {
        return await _context.Invitations
            .FirstOrDefaultAsync(i => i.Token == token);
    }

    private async Task<bool> IsUserAMemberOfTaskListAsync(string userId, int taskListId)
    {
        return await _context.TaskListMembers.AnyAsync(q => q.UserId == userId && q.TaskListId == taskListId);
    }

    private async Task<Category> CreateCategoryAsync(Category newCategory, string userId)
    {
        newCategory.UserId = userId;

        await _context.Categories.AddAsync(newCategory);
        await _context.SaveChangesAsync();
        return newCategory;
    }

    private async Task<Category?> GetCategoryByIdAsync(int categoryId)
    {
        return await _context.Categories.FindAsync(categoryId);
    }

    private async Task<bool> AssignCategoryAndTaskListToUserAsync(string userId, int taskListId, int categoryId)
    {
        await _context.UserTaskListCategories.AddAsync(
            new UserTaskListCategory
            {
                UserId = userId,
                TaskListId = taskListId,
                CategoryId = categoryId
            });

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    private async Task<bool> AcceptInviteAsync(Domain.Entities.Invitation invitation)
    {
        invitation.Status = InvitationStatus.Accepted;
        _context.Invitations.Update(invitation);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    private async Task<bool> AddUserToTaskListAsync(string userId, int taskListId)
    {
        var member = new TaskListMember
        {
            UserId = userId,
            TaskListId = taskListId,
            Role = TaskListRole.Viewer
        };

        await _context.TaskListMembers.AddAsync(member);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}