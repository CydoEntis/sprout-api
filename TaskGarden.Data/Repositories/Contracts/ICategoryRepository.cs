using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category?> GetByNameAsync(string userId, string categoryName);
    Task<IEnumerable<Category>> GetAllByUserIdAsync(string userId);

    Task<List<Category>> GetAllCategoriesTaskListsAsync(string userId);

    Task<bool> DeleteCategoryAndDependenciesAsync(Category category);
}