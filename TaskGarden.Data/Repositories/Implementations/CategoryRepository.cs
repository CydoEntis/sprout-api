using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetByNameAsync(string userId, string categoryName)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c =>
                c.UserId == userId && c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IEnumerable<Category>> GetAllByUserIdAsync(string userId)
    {
        return await _context.Categories.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<List<Category>> GetAllCategoriesTaskListsAsync(string userId)
    {
        return await _context.Categories.Where(c => c.UserId == userId).Include(c => c.TaskLists).ToListAsync();
    }

    // public async Task<List<Category>> GetAllTaskListsInCategoryAsync(int categoryId)
    // {
    //     return await _context.Categories.Where(c => c.Id == categoryId)
    //         .Include(c => c.TaskLists)
    //         .ThenInclude(tl => tl.TaskListItems)
    //         .Include(c => c.TaskLists)
    //         .ThenInclude(tl => tl.TaskListAssignments).ToListAsync();
    // }

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


    // public async Task<IEnumerable<Category>> GetAllCategoriesTaskListsAsync(string userId, string categoryName)
    // {
    //     return await _context.Categories
    //         .Include(c => c.TaskLists)
    //         .ThenInclude(tl => tl.User)
    //         .Include(c => c.TaskLists)
    //         .ThenInclude(tl => tl.TaskListItems)
    //         .Include(c => c.TaskLists)
    //         .ThenInclude(tl => tl.UserTaskLists)
    //         .Where(c => c.UserId == userId && c.Name.ToLower() == categoryName.ToLower())
    //         .ToListAsync();
    // }

    // public async Task<List<Category>> GetAllCategoriesWithTaskListsAsync(string userId, string categoryName)
    // {
    //     return await _context.Categories
    //         .Where(c => c.UserId == userId && c.Name.ToLower() == categoryName.ToLower())
    //         .Select(c => new Category
    //         {
    //             Id = c.Id,
    //             Name = c.Name,
    //             TaskLists = c.TaskLists.Select(tl => new TaskList
    //             {
    //                 Id = tl.Id,
    //                 Name = tl.Name,
    //                 TaskListItems = tl.TaskListItems.Select(tli => new TaskListItem
    //                 {
    //                     Id = tli.Id,
    //                     IsCompleted = tli.IsCompleted
    //                 }).ToList(),
    //                 UserTaskLists = tl.UserTaskLists.Select(utl => new TaskListAssignments
    //                 {
    //                     User = new AppUser
    //                     {
    //                         Id = utl.User.Id,
    //                         FirstName = utl.User.FirstName,
    //                         LastName = utl.User.LastName
    //                     }
    //                 }).ToList()
    //             }).ToList()
    //         }).ToListAsync();
    // }


    public async Task<List<CategoryWithTaskListCount>> GetCategoriesWithTaskListCountsForUserAsync(string userId)
    {
        var categories = await _context.Categories
            .Include(c => c.TaskLists)
            .Where(c => c.UserId == userId)
            .ToListAsync();

        var categoryTaskListCounts = categories.Select(c => new CategoryWithTaskListCount
        {
            Id = c.Id,
            CategoryName = c.Name,
            CategoryTag = c.Tag,
            TaskListCount = c.TaskLists.Count
        }).ToList();

        return categoryTaskListCounts;
    }
}