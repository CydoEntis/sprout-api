using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetCategoryByCategoryNameAsync(string categoryName);
    Task<IEnumerable<Category>> GetAllCategoriesForUserAsync(string userId);
    Task<List<CategoryAndCount>> GetCategoriesWithTaskListCountsForUserAsync(string userId);
}