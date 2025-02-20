using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Application.Common.Contracts;
public interface ITaskListRepository : IBaseRepository<TaskList>
{
    Task<TaskListDetails?> GetByIdAsync(int id);
    Task<List<TaskListOverview>> GetAllTaskListsInCategoryAsync(int categoryId);
}