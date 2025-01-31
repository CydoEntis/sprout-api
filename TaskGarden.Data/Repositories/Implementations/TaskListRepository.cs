using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class TaskListRepository : BaseRepository<TaskList>, ITaskListRepository
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<TaskList?> GetTaskListByIdForUser(string userId, int taskListId)
    {
        return await _context.TaskLists
            .Include(t => t.UserTaskLists)
            .ThenInclude(utl => utl.User)
            .Include(t => t.TaskListItems)
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == taskListId &&
                                      t.UserTaskLists.Any(utl => utl.UserId == userId));
    }
}