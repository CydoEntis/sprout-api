using System.Linq.Expressions;

namespace TaskGarden.Infrastructure.Repositories.Contracts;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetByIdsAsync(List<int> ids, Expression<Func<T, int>> idSelector);
    Task<T> AddAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task DeleteRangeAsync(List<T> entities);
    Task UpdateAsync(T entity);
    Task<bool> ExistsAsync(int id);
}