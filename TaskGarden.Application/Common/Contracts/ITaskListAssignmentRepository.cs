
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Common.Contracts;
public interface ITaskListAssignmentRepository : IBaseRepository<TaskListAssignments>
{
    Task<int> GetCountAsync(string userId, string categoryName);
    Task<string> GetAssignedRoleAsync(string userId, int taskListId);
    Task<TaskListAssignments?> GetByCategoryIdAsync(string userId, int categoryId);
}