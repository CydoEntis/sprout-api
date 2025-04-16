using Microsoft.EntityFrameworkCore;
using Sprout.Api.Domain.Entities;

namespace Sprout.Api.Application.Shared.Extensions;

public static class TaskListExtensions
{
    public static async Task<TaskList?> GetByIdAsync(this DbSet<TaskList> taskLists,
        int taskListId)
    {
        return await taskLists.FindAsync(taskListId);
    }

    public static async Task<bool> ExistsAsync(this DbSet<TaskList> taskLists,
        int taskListId)
    {
        return await taskLists.AnyAsync(q => q.Id == taskListId);
    }
}