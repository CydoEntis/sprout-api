using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Common.Contracts;

public interface IUserTaskListCategoryRepository : IBaseRepository<UserTaskListCategory>
{
    Task<UserTaskListCategory?> GetByUserAndTaskListAsync(string userId, int taskListId);
    Task<List<UserTaskListCategory>> GetByUserAsync(string userId);
    Task<int> GetTaskListCountByCategoryAsync(string userId, int categoryId);
}