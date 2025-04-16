using Sprout.Api.Domain.Entities;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Shared.Extensions
{
    public static class UserTaskListCategoryExtensions
    {
        public static async Task<bool> AssignCategoryAndTaskListAsync(
            this AppDbContext context,
            string userId,
            int taskListId,
            int categoryId)
        {
            await context.UserTaskListCategories.AddAsync(new UserTaskListCategory
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
            await context.UserTaskListCategories.AddAsync(new UserTaskListCategory
            {
                UserId = userId,
                CategoryId = categoryId
            });

            return await context.SaveChangesAsync() > 0;
        }
    }
}