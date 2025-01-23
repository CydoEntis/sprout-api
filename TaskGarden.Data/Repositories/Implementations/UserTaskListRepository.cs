using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class UserTaskListRepository : BaseRepository<UserTaskList>, IUserTaskListRepository
{
    public UserTaskListRepository(AppDbContext context) : base(context)
    {
    }
}