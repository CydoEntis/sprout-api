using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    
    public async Task<List<T>> GetByIdsAsync(List<int> ids, Expression<Func<T, int>> idSelector)
    {
        var compiledSelector = idSelector.Compile(); 

        return await _context.Set<T>()
            .Where(e => ids.Contains(compiledSelector(e))) 
            .ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task DeleteRangeAsync(List<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);  // Removes the provided entities from the DbSet
        await _context.SaveChangesAsync();        // Persists the changes to the database
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Set<T>().AnyAsync(q => q.Id == id);
    }
}