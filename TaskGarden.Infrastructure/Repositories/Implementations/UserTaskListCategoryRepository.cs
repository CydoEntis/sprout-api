using Microsoft.EntityFrameworkCore;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Implementations;

public class UserTaskListCategoryRepository : BaseRepository<UserTaskListCategory>, IUserTaskListCategoryRepository
{
    public UserTaskListCategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<UserTaskListCategory?> GetByUserAndTaskListAsync(string userId, int taskListId)
    {
        return await _context.UserTaskListCategories
            .Where(utl => utl.UserId == userId && utl.TaskListId == taskListId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<UserTaskListCategory>> GetByUserAsync(string userId)
    {
        return await _context.UserTaskListCategories
            .Where(utl => utl.UserId == userId)
            .ToListAsync();
    }

    public async Task<int> GetTaskListCountByCategoryAsync(string userId, int categoryId)
    {
        return await _context.UserTaskListCategories
            .Where(utl => utl.UserId == userId && utl.CategoryId == categoryId)
            .CountAsync();
    }
}