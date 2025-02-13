using TaskGarden.Data.Models;
using TaskGarden.Data.Projections;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ITaskListRepository : IBaseRepository<TaskList>
{
    Task<TaskListDetails?> GetByIdAsync(int id);
    Task<List<TaskListOverview>> GetAllTaskListsInCategoryAsync(int categoryId);
}