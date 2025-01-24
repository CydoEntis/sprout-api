using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface IUserTaskListRepository : IBaseRepository<UserTaskList>
{
    Task<int> GetTaskListCountByCategoryForUserAsync(string userId, string categoryName);
}