using Microsoft.EntityFrameworkCore;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Implementations;



public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetByNameAsync(string userId, string categoryName)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c =>
                c.UserId == userId && c.Name.ToLower() == categoryName.ToLower());
    }

    public async Task<IEnumerable<Category>> GetAllByUserIdAsync(string userId)
    {
        return await _context.Categories.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<List<Category>> GetAllCategoriesTaskListsAsync(string userId)
    {
        return await _context.Categories.Where(c => c.UserId == userId).Include(c => c.TaskLists).ToListAsync();
    }


    public async Task<bool> DeleteCategoryAndDependenciesAsync(Category category)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var categoryId = category.Id;
            var taskListIds = await _context.TaskLists
                .Where(t => t.CategoryId == categoryId)
                .Select(t => t.Id)
                .ToListAsync();

            if (taskListIds.Count > 0)
            {
                await _context.TaskListAssignments
                    .Where(tla => taskListIds.Contains(tla.TaskListId))
                    .ExecuteDeleteAsync();

                await _context.TaskListItems
                    .Where(tli => taskListIds.Contains(tli.TaskListId))
                    .ExecuteDeleteAsync();

                await _context.TaskLists
                    .Where(t => taskListIds.Contains(t.Id))
                    .ExecuteDeleteAsync();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

}