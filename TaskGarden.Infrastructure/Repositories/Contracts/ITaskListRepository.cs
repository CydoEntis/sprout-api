using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Infrastructure.Repositories.Contracts;


public interface ITaskListRepository : IBaseRepository<TaskList>
{
    Task<TaskListDetails?> GetByIdAsync(int id);
    Task<List<TaskListOverview>> GetAllTaskListsInCategoryAsync(int categoryId);
}