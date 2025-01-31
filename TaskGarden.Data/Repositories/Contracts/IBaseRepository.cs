namespace TaskGarden.Data.Repositories.Contracts;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task DeleteRangeAsync(List<T> entities);
    Task UpdateAsync(T entity);
    Task<bool> ExistsAsync(int id);
}