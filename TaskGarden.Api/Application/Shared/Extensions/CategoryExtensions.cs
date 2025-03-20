using Microsoft.EntityFrameworkCore;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Api.Extensions;

public static class CategoryExtensions
{
    public static async Task<bool> CategoryExistsAsync(this DbSet<Category> categories, string categoryName,
        string userId)
    {
        return await categories
            .AnyAsync(c => c.UserId == userId && c.Name.ToLower() == categoryName.ToLower());
    }

    public static async Task<Category?> GetByIdAsync(this DbSet<Category> categories, string userId, int categoryId)
    {
        return await categories
            .FirstOrDefaultAsync(c => c.Id == categoryId && c.UserId == userId);
    }
}