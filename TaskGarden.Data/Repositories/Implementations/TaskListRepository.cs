using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class TaskListRepository : BaseRepository<TaskList>, ITaskListRepository
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Category>> GetAllTaskListsByCategoryForUser(string userId, string categoryName)
    {
        return await _context.TaskList.Where(c => c.UserId == userId && c.Category == categoryName).ToListAsync();
    }
}