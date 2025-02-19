using Microsoft.EntityFrameworkCore;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Repositories.Contracts;

namespace TaskGarden.Infrastructure.Repositories.Implementations;

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