using TaskGarden.Data.Models;
using TaskGarden.Data.Projections;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ITaskListRepository : IBaseRepository<TaskList>
{
    Task<TaskList?> GetByIdAsync(string userId, int id);
    // Task<List<TaskList>> GetAllTaskListsInCategoryAsync(int categoryId);
    Task<List<TaskListOverview>> GetAllTaskListsInCategoryAsync(int categoryId);
}