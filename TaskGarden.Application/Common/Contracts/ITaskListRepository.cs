using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Application.Common.Contracts;

public interface ITaskListRepository : IBaseRepository<TaskList>
{
    Task<TaskList?> GetByIdAsync(int id);
    Task<TaskListDetails?> GetDetailsByIdAsync(int id);
    Task<List<TaskListOverview>> GetAllTaskListsInCategoryAsync(int categoryId);
    Task<bool> DeleteTaskListAndDependenciesAsync(TaskList taskList);
}