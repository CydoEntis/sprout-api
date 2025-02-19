using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Contracts;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category?> GetByNameAsync(string userId, string categoryName);
    Task<IEnumerable<Category>> GetAllByUserIdAsync(string userId);

    Task<List<Category>> GetAllCategoriesTaskListsAsync(string userId);

    Task<bool> DeleteCategoryAndDependenciesAsync(Category category);
}