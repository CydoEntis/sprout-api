using TaskGarden.Api.Domain.Entities;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Shared.Extensions
{
    public static class UserTaskListCategoryExtensions
    {
        public static async Task<bool> AssignCategoryAndTaskListAsync(
            this AppDbContext context,
            string userId,
            int taskListId,
            int categoryId)
        {
            await context.UserTasklistCategories.AddAsync(new UserTasklistCategory
            {
                UserId = userId,
                TaskListId = taskListId,
                CategoryId = categoryId
            });

            return await context.SaveChangesAsync() > 0;
        }

        public static async Task<bool> AssignCategoryAsync(
            this AppDbContext context,
            string userId,
            int categoryId)
        {
            await context.UserTasklistCategories.AddAsync(new UserTasklistCategory
            {
                UserId = userId,
                CategoryId = categoryId
            });

            return await context.SaveChangesAsync() > 0;
        }
    }
}