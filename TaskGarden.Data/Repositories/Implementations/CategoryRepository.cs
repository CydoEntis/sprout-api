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

    public async Task<IEnumerable<Category>> GetAll(string userId)
    {
        return await _context.Categories.Where(c => c.UserId == userId).ToListAsync();
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

    public async Task<List<Category>> GetAllCategoriesWithTaskListsAsync(string userId, string categoryName)
    {
        return await _context.Categories
            .Where(c => c.UserId == userId && c.Name.ToLower() == categoryName.ToLower())
            .Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name,
                TaskLists = c.TaskLists.Select(tl => new TaskList
                {
                    Id = tl.Id,
                    Name = tl.Name,
                    TaskListItems = tl.TaskListItems.Select(tli => new TaskListItem
                    {
                        Id = tli.Id,
                        IsCompleted = tli.IsCompleted
                    }).ToList(),
                    UserTaskLists = tl.UserTaskLists.Select(utl => new TaskListAssignments
                    {
                        User = new AppUser
                        {
                            Id = utl.User.Id,
                            FirstName = utl.User.FirstName,
                            LastName = utl.User.LastName
                        }
                    }).ToList()
                }).ToList()
            }).ToListAsync();
    }


    public async Task<List<CategoryWithCount>> GetCategoriesWithTaskListCountsForUserAsync(string userId)
    {
        var categories = await _context.Categories
            .Include(c => c.TaskLists)
            .Where(c => c.UserId == userId)
            .ToListAsync();

        var categoryTaskListCounts = categories.Select(c => new CategoryWithCount
        {
            Id = c.Id,
            CategoryName = c.Name,
            CategoryTag = c.Tag,
            TaskListCount = c.TaskLists.Count
        }).ToList();

        return categoryTaskListCounts;
    }
}