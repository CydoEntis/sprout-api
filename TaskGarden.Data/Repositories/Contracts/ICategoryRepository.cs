using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetCategoryByCategoryName(string categoryName);
}