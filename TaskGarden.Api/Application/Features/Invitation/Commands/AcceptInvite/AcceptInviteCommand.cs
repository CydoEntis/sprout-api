﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Api.Domain.Enums;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Invitation.Commands.AcceptInvite;

public record AcceptInviteCommand(string Token, int? CategoryId, NewCategoryCommand? NewCategory)
    : IRequest<AcceptInviteCommandResponse>;

public record NewCategoryCommand(string Name, string Tag, string Color);

public class AcceptInviteCommandResponse : BaseResponse
{
    public string CategoryName { get; set; } = "No category assigned";
    public int TasklistId { get; set; }
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
        var invitation = await _context.Invitations.GetByInviteTokenAsync(request.Token);

        if (invitation is null || invitation.Status != InvitationStatus.Pending ||
            invitation.ExpiresAt < DateTime.UtcNow)
            throw new NotFoundException("Invite has expired, has already been accepted, or does not exist");

        if (await _context.TasklistMembers.IsMemberAsync(userId, invitation.TasklistId))
            throw new ConflictException("User is already part of this task list");

        Category? category = null;

        if (request.NewCategory is not null)
        {
            var newCategory = _mapper.Map<Category>(request.NewCategory);
            newCategory.UserId = userId;
            category = await _context.CreateCategoryAsync(newCategory);
        }
        else if (request.CategoryId.HasValue)
        {
            category = await _context.Categories.GetByIdAsync(request.CategoryId.Value)
                       ?? throw new NotFoundException("Category not found.");
        }

        if (category is null)
            throw new NotFoundException("Category not found.");

        var categoryAssigned =
            await _context.AssignCategoryAndTaskListAsync(userId, invitation.TasklistId, category.Id);
        if (!categoryAssigned)
            throw new ApplicationException("Failed to assign category to the user.");

        var inviteAccepted = await AcceptInviteAsync(invitation);
        if (!inviteAccepted)
            throw new ApplicationException("Failed to update invitation status.");

        var addedToTaskList = await _context.AssignUserAsync(userId, invitation.TasklistId);
        if (!addedToTaskList)
            throw new ApplicationException("Failed to add user to the task list.");


        var roleAssigned = await AssignUserRoleAsync(userId, invitation.TasklistId, invitation.Role);
        if (!roleAssigned)
            throw new ApplicationException("Failed to assign the role to the user.");

        return new AcceptInviteCommandResponse
        {
            Message = "Invite accepted",
            TasklistId = invitation.TasklistId,
            CategoryName = category?.Name ?? "No category assigned"
        };
    }

    private async Task<bool> AssignUserRoleAsync(string userId, int taskListId, TaskListRole role)
    {
        var taskListMember = await _context.TasklistMembers
            .FirstOrDefaultAsync(m => m.UserId == userId && m.TasklistId == taskListId);

        if (taskListMember == null)
            return false;

        taskListMember.Role = role;
        _context.TasklistMembers.Update(taskListMember);

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
}