using Microsoft.EntityFrameworkCore;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Models;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Implementations;

public class TaskListItemRepository : BaseRepository<TaskListItem>, ITaskListItemRepository
{
    public TaskListItemRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddTaskListItemAsync(TaskListItem taskListItem)
    {
        int maxPosition = await _context.TaskListItems
            .Where(i => i.TaskListId == taskListItem.TaskListId)
            .Select(i => (int?)i.Position)
            .MaxAsync() ?? 0;

        taskListItem.Position = maxPosition + 1;

        await _context.TaskListItems.AddAsync(taskListItem);
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<TaskListItem>> GetAllTasksForTaskList(int taskListId)
    {
        return await _context.TaskListItems.Where(t => t.TaskListId == taskListId).ToListAsync();
    }

    public async Task<TaskListItem> GetByIdAsync(int taskListItemId)
    {
        return await _context.TaskListItems.FirstOrDefaultAsync(q => q.Id == taskListItemId);
    }

    public async Task ReorderTaskListItemsAsync(int taskListId, List<ListItemOrder> items)
    {
        var taskListItems = await _context.TaskListItems
            .Where(i => i.TaskListId == taskListId)
            .ToListAsync();

        foreach (var item in items)
        {
            var taskItem = taskListItems.FirstOrDefault(i => i.Id == item.Id);
            if (taskItem != null)
            {
                taskItem.Position = item.Position;
            }
        }

        await _context.SaveChangesAsync();
    }
}