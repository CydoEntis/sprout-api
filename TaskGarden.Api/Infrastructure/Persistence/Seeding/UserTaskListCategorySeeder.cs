using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Seeders;

public class UserTaskListCategorySeeder : IEntityTypeConfiguration<UserTaskListCategory>
{
    public void Configure(EntityTypeBuilder<UserTaskListCategory> builder)
    {
        var demoUser1Id = "1b503418-dc0f-4187-93c0-2e30070b2835";
        var demoUser2Id = "9e22a16c-da04-4232-b479-95c3a7b89259";
        var demoUser3Id = "40fcec36-7eef-42d8-8086-cd2226b88d00";
        
        builder.HasData(
            new UserTaskListCategory
            {
                UserId = demoUser1Id,
                TaskListId = 1,
                CategoryId = 1
            },
            new UserTaskListCategory
            {
                UserId = demoUser1Id,
                TaskListId = 2,
                CategoryId = 1
            },
            new UserTaskListCategory
            {
                UserId = demoUser1Id,
                TaskListId = 3,
                CategoryId = 2
            },
            new UserTaskListCategory
            {
                UserId = demoUser1Id,
                TaskListId = 4,
                CategoryId = 2
            },
            new UserTaskListCategory
            {
                UserId = demoUser1Id,
                TaskListId = 5,
                CategoryId = 3
            },
            new UserTaskListCategory
            {
                UserId = demoUser1Id,
                TaskListId = 6,
                CategoryId = 3
            },
            new UserTaskListCategory
            {
                UserId = demoUser1Id,
                TaskListId = 7,
                CategoryId = 4
            },
            new UserTaskListCategory
            {
                UserId = demoUser1Id,
                TaskListId = 8,
                CategoryId = 5
            },

            // Demo User 2 Categories
            new UserTaskListCategory
            {
                UserId = demoUser2Id,
                TaskListId = 9,
                CategoryId = 6
            },
            new UserTaskListCategory
            {
                UserId = demoUser2Id,
                TaskListId = 10,
                CategoryId = 7
            },

            // Demo User 3 Categories
            new UserTaskListCategory
            {
                UserId = demoUser3Id,
                TaskListId = 11,
                CategoryId = 8
            },
            new UserTaskListCategory
            {
                UserId = demoUser3Id,
                TaskListId = 12,
                CategoryId = 8
            },
            new UserTaskListCategory
            {
                UserId = demoUser3Id,
                TaskListId = 13,
                CategoryId = 9
            },
            new UserTaskListCategory
            {
                UserId = demoUser3Id,
                TaskListId = 14,
                CategoryId = 10
            }
        );
    }
}