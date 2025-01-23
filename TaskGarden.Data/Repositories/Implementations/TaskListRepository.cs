using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class TaskListRepository : BaseRepository<TaskList>, ITaskListRepository
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TaskList>> GetAllTaskListsByCategoryForUser(string userId, string categoryName)
    {
        return await _context.TaskLists
            .Include(t => t.UserTaskLists)
            .ThenInclude(utl => utl.User)
            .Where(c => c.UserId == userId && c.Category == categoryName)
            .ToListAsync();
    }
}