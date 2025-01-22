using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class TaskListRepository : BaseRepository<TaskList>, ITaskListRepository
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }
}