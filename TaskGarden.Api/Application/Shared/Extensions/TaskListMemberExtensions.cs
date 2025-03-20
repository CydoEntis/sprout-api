using Microsoft.EntityFrameworkCore;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Shared.Extensions;

public static class TaskListMemberExtensions
{
    public static async Task<bool> IsUserAMemberOfTaskListAsync(this DbSet<TaskListMember> taskListMembers,
        string userId,
        int taskListId)
    {
        return await taskListMembers.AnyAsync(q => q.UserId == userId && q.TaskListId == taskListId);
    }

    public static async Task<bool> AssignUserToTaskListAsync(this AppDbContext context, string userId,
        int taskListId)
    {
        await context.TaskListMembers.AddAsync(new TaskListMember
        {
            UserId = userId,
            TaskListId = taskListId,
            Role = TaskListRole.Owner
        });

        return await context.SaveChangesAsync() > 0;
    }
}