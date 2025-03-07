using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Application.Common.Contracts;

public interface ITaskListRepository : IBaseRepository<TaskList>
{
    Task<TaskList?> GetByIdAsync(int id);
    Task<TaskListPreview?> GetDetailsByIdAsync(int id);
    Task<List<TaskListPreview>> GetAllTaskListsInCategoryAsync(int categoryId);
    Task<bool> DeleteTaskListAndDependenciesAsync(TaskList taskList);
}