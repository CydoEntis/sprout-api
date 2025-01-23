using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class TaskListItemRepository : BaseRepository<TaskListItem>, ITaskListItemRepository
{
    public TaskListItemRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TaskListItem>> GetAllTasksForTaskList(int taskListId)
    {
        return await _context.TaskListItems.Where(t => t.TaskListId == taskListId).ToListAsync();
    }
}