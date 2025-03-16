using TaskGarden.Application.Projections;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Application.Common.Contracts;

public interface IUserTaskListCategoryRepository : IBaseRepository<UserTaskListCategory>
{
    Task<List<CategoryWithTaskListCount>> GetCategoryPreviewByUserId(string userId);
    Task<UserTaskListCategory?> GetByUserAndTaskListAsync(string userId, int taskListId);
    Task<List<UserTaskListCategory>> GetByUserAsync(string userId);
    Task<int> GetTaskListCountByCategoryAsync(string userId, int categoryId);

    Task<List<TaskListPreview>> GetAllTaskListsByUserIdAndCategoryId(string userId,
        int categoryId);
}