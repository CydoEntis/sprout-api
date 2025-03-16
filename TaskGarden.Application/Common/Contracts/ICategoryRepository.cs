using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Common.Contracts;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category?> GetByIdAsync(string userId, int categoryId);
    Task<Category?> GetByNameAsync(string userId, string categoryName);
    Task<IEnumerable<Category>> GetAllByUserIdAsync(string userId);

    Task<List<Category>> GetAllCategoriesTaskListsAsync(string userId);

    Task<bool> DeleteCategoryAndDependenciesAsync(Category category);
    Task<bool> CategoryExistsAsync(string userId, string categoryName);
}