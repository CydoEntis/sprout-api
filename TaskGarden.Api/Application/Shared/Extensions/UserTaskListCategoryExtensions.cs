using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Shared.Extensions
{
    public static class UserTaskListCategoryExtensions
    {
        public static async Task<bool> AssignAsync(
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
    }
}