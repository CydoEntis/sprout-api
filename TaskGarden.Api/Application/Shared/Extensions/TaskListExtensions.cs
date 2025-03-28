using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Application.Shared.Extensions;

public static class TaskListExtensions
{
    public static async Task<Tasklist?> GetByIdAsync(this DbSet<Tasklist> taskLists,
        int taskListId)
    {
        return await taskLists.FindAsync(taskListId);
    }

    public static async Task<bool> ExistsAsync(this DbSet<Tasklist> taskLists,
        int taskListId)
    {
        return await taskLists.AnyAsync(q => q.Id == taskListId);
    }
}