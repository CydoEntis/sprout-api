using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Application.Shared.Extensions;

public static class TaskListItemExtensions
{
    public static async Task<TasklistItem?> ExistsAsync(this DbSet<TasklistItem> taskListsItems,
        int taskListItemId)
    {
        return await taskListsItems.FirstOrDefaultAsync(tli => tli.Id == taskListItemId);
    }
    
    public static async Task<TasklistItem?> GetByIdAsync(this DbSet<TasklistItem> taskListsItems,
        int taskListItemId)
    {
        return await taskListsItems.FirstOrDefaultAsync(q => q.Id == taskListItemId);
    }
}