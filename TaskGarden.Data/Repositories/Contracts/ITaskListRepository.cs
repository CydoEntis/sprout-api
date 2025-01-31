using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ITaskListRepository : IBaseRepository<TaskList>
{
    // Task<IEnumerable<TaskList>> GetAllTaskListsByCategoryForUser(string userId, string categoryName);
    Task<TaskList?> GetByUserIdAsync(string userId, int taskListId);
    Task<List<TaskList>> GetByCategoryIdAsync(string userId, int categoryId);
}