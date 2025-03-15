using Microsoft.EntityFrameworkCore;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Projections;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Implementations;

public class UserTaskListCategoryRepository : BaseRepository<UserTaskListCategory>, IUserTaskListCategoryRepository
{
    public UserTaskListCategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<CategoryWithTaskListCount>> GetCategoryPreviewByUserId(string userId)
    {
        var categories = await _context.UserTaskListCategories
            .Where(ut => ut.UserId == userId)
            .Include(ut => ut.Category)
            .Include(ut => ut.TaskList)
            .GroupBy(ut => ut.Category)
            .Select(g => new CategoryWithTaskListCount
            {
                Category = g.Key,
                TaskListCount = g.Count()
            })
            .ToListAsync();

        return categories;
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