using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface IUserTaskListRepository : IBaseRepository<TaskListAssignments>
{
    Task<int> GetTaskListCountByCategoryForUserAsync(string userId, string categoryName);
    Task<string> GetUserRoleForTaskListAsync(string userId, int taskListId);
    Task<TaskListAssignments?> GetUserTaskListByUserAndCategoryIdAsync(string userId, int categoryId);
}