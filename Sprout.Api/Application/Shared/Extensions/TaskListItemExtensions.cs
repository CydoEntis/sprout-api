using Microsoft.EntityFrameworkCore;
using Sprout.Api.Domain.Entities;

namespace Sprout.Api.Application.Shared.Extensions;

public static class TaskListItemExtensions
{
    public static async Task<TaskListItem?> ExistsAsync(this DbSet<TaskListItem> taskListsItems,
        int taskListItemId)
    {
        return await taskListsItems.FirstOrDefaultAsync(tli => tli.Id == taskListItemId);
    }
    
    public static async Task<TaskListItem?> GetByIdAsync(this DbSet<TaskListItem> taskListsItems,
        int taskListItemId)
    {
        return await taskListsItems.FirstOrDefaultAsync(q => q.Id == taskListItemId);
    }
}