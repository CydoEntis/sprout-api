using Microsoft.EntityFrameworkCore;
using Sprout.Api.Domain.Entities;
using Sprout.Api.Domain.Enums;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Domain.Enums;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Shared.Extensions;

public static class TaskListMemberExtensions
{
    public static async Task<bool> IsMemberAsync(this DbSet<TaskListMember> taskListMembers,
        string userId,
        int taskListId)
    {
        return await taskListMembers.AnyAsync(q => q.UserId == userId && q.TasklistId == taskListId);
    }

    public static async Task<bool> AssignUserAsync(this AppDbContext context, string userId,
        int taskListId)
    {
        await context.TaskListMembers.AddAsync(new TaskListMember
        {
            UserId = userId,
            TasklistId = taskListId,
            Role = TaskListRole.Owner
        });

        return await context.SaveChangesAsync() > 0;
    }

    public static async Task<bool> IsOwnerOrEditorAsync(this DbSet<TaskListMember> taskListMembers, string userId,
        int taskListId)
    {
        return await taskListMembers.AnyAsync(q =>
            q.UserId == userId && q.TasklistId == taskListId &&
            (q.Role == TaskListRole.Owner || q.Role == TaskListRole.Editor));
    }
}