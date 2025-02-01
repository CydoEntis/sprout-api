using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ITaskListRepository : IBaseRepository<TaskList>
{
    Task<List<TaskList>> GetAllTaskListsInCategoryAsync(int categoryId);
}