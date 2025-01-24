using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetCategoryByCategoryNameAsync(string categoryName)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == categoryName.ToLower());
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesForUserAsync(string userId)
    {
        return await _context.Categories.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<List<CategoryAndCount>> GetCategoriesWithTaskListCountsForUserAsync(string userId)
    {
        var categories = await _context.Categories
            .Include(c => c.TaskLists)
            .Where(c => c.UserId == userId)
            .ToListAsync();

        var categoryTaskListCounts = categories.Select(c => new CategoryAndCount
        {
            Id = c.Id,
            CategoryName = c.Name,
            CategoryTag = c.Tag,
            TaskListCount = c.TaskLists.Count
        }).ToList();

        return categoryTaskListCounts;
    }
}