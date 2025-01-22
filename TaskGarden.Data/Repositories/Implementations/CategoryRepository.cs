using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetCategoryByCategoryName(string categoryName)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == categoryName.ToLower());
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesForUser(string userId)
    {
        return await _context.Categories.Where(c => c.UserId == userId).ToListAsync();
    }
}