using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ITaskListAssignmentRepository : IBaseRepository<TaskListAssignments>
{
    Task<int> GetCount(string userId, string categoryName);
    Task<string> GetAssignedRole(string userId, int taskListId);
    Task<TaskListAssignments?> GetByCategoryIdAsync(string userId, int categoryId);
}