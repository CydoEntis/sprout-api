using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Api.Domain.Enums;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Domain.Common;

namespace TaskGarden.Api.Application.Features.Demo
{
    public static class SeedDataManager
    {
        private static readonly string demoUser1Id = "1b503418-dc0f-4187-93c0-2e30070b2835";
        private static readonly string demoUser2Id = "9e22a16c-da04-4232-b479-95c3a7b89259";
        private static readonly string demoUser3Id = "40fcec36-7eef-42d8-8086-cd2226b88d00";

        public static async Task ClearAndReseedDatabase(AppDbContext context)
        {
            var demoUserIds = new[] { demoUser1Id, demoUser2Id, demoUser3Id };

            context.Categories.RemoveRange(context.Categories.Where(c => demoUserIds.Contains(c.UserId)));
            context.TaskLists.RemoveRange(context.TaskLists.Where(tl => demoUserIds.Contains(tl.CreatedById)));
            context.TaskListMembers.RemoveRange(context.TaskListMembers.Where(tlm => demoUserIds.Contains(tlm.UserId)));

            var taskListIds = context.TaskLists
                .Where(tl => demoUserIds.Contains(tl.CreatedById))
                .Select(tl => tl.Id)
                .ToList();

            context.TaskListItems.RemoveRange(context.TaskListItems.Where(tli => taskListIds.Contains(tli.TasklistId)));

            context.UserTaskListCategories.RemoveRange(
                context.UserTaskListCategories.Where(utlc => demoUserIds.Contains(utlc.UserId)));

            await context.SaveChangesAsync();

            await SeedCategories(context);
            await SeedTaskLists(context);
            await SeedTaskListMembers(context);
            await SeedTaskListItems(context);
            await SeedUserTaskListCategories(context);
            await SeedFavoriteTaskLists(context);
        }

        private static async Task SeedCategories(AppDbContext context)
        {
            context.Categories.AddRange(
                // Demo User 1 Categories
                new Category
                {
                    Id = 1,
                    Name = "Groceries",
                    Tag = CategoryIcon.ShoppingCart.Tag,
                    Color = "#1971C2",
                    UserId = demoUser1Id
                },
                new Category
                {
                    Id = 2,
                    Name = "Bills",
                    Tag = CategoryIcon.Banknote.Tag,
                    Color = "#E03131",
                    UserId = demoUser1Id
                },
                new Category
                {
                    Id = 3,
                    Name = "Entertainment",
                    Tag = CategoryIcon.RollerCoaster.Tag,
                    Color = "#1971C2",
                    UserId = demoUser1Id
                },
                new Category
                {
                    Id = 4,
                    Name = "Travel",
                    Tag = CategoryIcon.Plane.Tag,
                    Color = "#F08C00",
                    UserId = demoUser1Id
                },
                new Category
                {
                    Id = 5,
                    Name = "School",
                    Tag = CategoryIcon.University.Tag,
                    Color = "#9C36B5",
                    UserId = demoUser1Id
                },

                // Demo User 2 Categories
                new Category
                {
                    Id = 6,
                    Name = "Groceries",
                    Tag = CategoryIcon.ShoppingCart.Tag,
                    Color = "#0C8599",
                    UserId = demoUser2Id
                },
                new Category
                {
                    Id = 7,
                    Name = "Bills",
                    Tag = CategoryIcon.Receipt.Tag,
                    Color = "#E8590C",
                    UserId = demoUser2Id
                },

                // Demo User 3 Categories
                new Category
                {
                    Id = 8,
                    Name = "Groceries",
                    Tag = CategoryIcon.ShoppingBasket.Tag,
                    Color = "#6741D9",
                    UserId = demoUser3Id
                },
                new Category
                {
                    Id = 9,
                    Name = "Bills",
                    Tag = CategoryIcon.HandCoins.Tag,
                    Color = "#099268",
                    UserId = demoUser3Id
                },
                new Category
                {
                    Id = 10,
                    Name = "Entertainment",
                    Tag = CategoryIcon.Theater.Tag,
                    Color = "#C2255C",
                    UserId = demoUser3Id
                }
            );
            await context.SaveChangesAsync();
        }

        private static async Task SeedTaskLists(AppDbContext context)
        {
            context.TaskLists.AddRange(
                // Demo User 1 TaskLists
                new Domain.Entities.TaskList
                {
                    Id = 1, Name = "ShopRite shopping list", Description = "This week's shopping list for ShopRite",
                    CreatedById = demoUser1Id
                },
                new Domain.Entities.TaskList
                {
                    Id = 2, Name = "Walmart shopping list", Description = "This week's shopping list for Walmart",
                    CreatedById = demoUser1Id
                },
                new Domain.Entities.TaskList
                {
                    Id = 3, Name = "Rent payment", Description = "Monthly rent payment reminders",
                    CreatedById = demoUser1Id
                },
                new Domain.Entities.TaskList
                {
                    Id = 4, Name = "Electricity Bill", Description = "Electricity bill payment reminders",
                    CreatedById = demoUser1Id
                },
                new Domain.Entities.TaskList
                {
                    Id = 5, Name = "Movie night", Description = "List of movies to watch this weekend",
                    CreatedById = demoUser1Id
                },
                new Domain.Entities.TaskList
                {
                    Id = 6,
                    Name = "Concert Tickets",
                    Description = "Track upcoming concerts and events",
                    CreatedById = demoUser1Id,
                },
                new Domain.Entities.TaskList
                {
                    Id = 7,
                    Name = "Vacation Planning",
                    Description = "Plan and book flights and hotels",
                    CreatedById = demoUser1Id,
                },
                new Domain.Entities.TaskList
                {
                    Id = 8,
                    Name = "Assignment Deadlines",
                    Description = "Track deadlines for assignments",
                    CreatedById = demoUser1Id,
                },
                // Demo User 2 TaskLists
                new Domain.Entities.TaskList
                {
                    Id = 9, Name = "Giant shopping list", Description = "Weekly shopping list for Giant",
                    CreatedById = demoUser2Id
                },
                new Domain.Entities.TaskList
                {
                    Id = 10, Name = "Internet Bill", Description = "Track Internet bill payments",
                    CreatedById = demoUser2Id
                },
                // Demo User 3 TaskLists
                new Domain.Entities.TaskList
                {
                    Id = 11, Name = "SuperMart shopping list", Description = "Grocery list for SuperMart",
                    CreatedById = demoUser3Id
                },
                new Domain.Entities.TaskList
                {
                    Id = 12, Name = "Local Market shopping list", Description = "List of items for the local market",
                    CreatedById = demoUser3Id
                },
                new Domain.Entities.TaskList
                {
                    Id = 13, Name = "Mobile Bill", Description = "Keep track of monthly mobile bills",
                    CreatedById = demoUser3Id
                },
                new Domain.Entities.TaskList
                {
                    Id = 14, Name = "Weekend Fun Activities", Description = "List of fun things to do this weekend",
                    CreatedById = demoUser3Id
                }
            );
            await context.SaveChangesAsync();
        }

        private static async Task SeedTaskListMembers(AppDbContext context)
        {
            context.TaskListMembers.AddRange(
                // Owner is Demo User 1
                new TaskListMember
                {
                    Id = 1,
                    TasklistId = 1,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 2,
                    TasklistId = 2,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 3,
                    TasklistId = 3,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 4,
                    TasklistId = 4,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 5,
                    TasklistId = 5,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 6,
                    TasklistId = 6,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 7,
                    TasklistId = 7,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 8,
                    TasklistId = 8,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Owner
                },
                // Owner is Demo User 2
                new TaskListMember
                {
                    Id = 9,
                    TasklistId = 9,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 10,
                    TasklistId = 10,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Owner
                },
                // Owner is Demo User 3
                new TaskListMember
                {
                    Id = 11,
                    TasklistId = 11,
                    UserId = demoUser3Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 12,
                    TasklistId = 12,
                    UserId = demoUser3Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 13,
                    TasklistId = 13,
                    UserId = demoUser3Id,
                    Role = TaskListRole.Owner
                },
                new TaskListMember
                {
                    Id = 14,
                    TasklistId = 14,
                    UserId = demoUser3Id,
                    Role = TaskListRole.Owner
                },
                // Adding Additional Members
                new TaskListMember
                {
                    Id = 15,
                    TasklistId = 1,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 16,
                    TasklistId = 2,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 17,
                    TasklistId = 3,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 18,
                    TasklistId = 4,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 19,
                    TasklistId = 5,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 20,
                    TasklistId = 6,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 21,
                    TasklistId = 7,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 22,
                    TasklistId = 8,
                    UserId = demoUser2Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 23,
                    TasklistId = 9,
                    UserId = demoUser3Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 24,
                    TasklistId = 10,
                    UserId = demoUser3Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 25,
                    TasklistId = 11,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 26,
                    TasklistId = 12,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 27,
                    TasklistId = 13,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Viewer
                },
                new TaskListMember
                {
                    Id = 28,
                    TasklistId = 14,
                    UserId = demoUser1Id,
                    Role = TaskListRole.Viewer
                }
            );
            await context.SaveChangesAsync();
        }

        private static async Task SeedTaskListItems(AppDbContext context)
        {
            var random = new Random();
            var items = new List<Domain.Entities.TaskListItem>
            {
                new() { Id = 1, TasklistId = 1, Description = "Buy milk", DueDate = DateTime.UtcNow.AddDays(1) },
                new() { Id = 2, TasklistId = 1, Description = "Buy eggs", DueDate = DateTime.UtcNow.AddDays(2) },
                new() { Id = 3, TasklistId = 1, Description = "Buy bread", DueDate = DateTime.UtcNow.AddDays(3) },
                new() { Id = 4, TasklistId = 2, Description = "Buy eggs", DueDate = DateTime.UtcNow.AddDays(1) },
                new() { Id = 5, TasklistId = 2, Description = "Buy milk", DueDate = DateTime.UtcNow.AddDays(2) },
                new() { Id = 6, TasklistId = 3, Description = "Pay rent", DueDate = DateTime.UtcNow.AddDays(1) },
                new()
                {
                    Id = 7, TasklistId = 4, Description = "Pay electricity bill", DueDate = DateTime.UtcNow.AddDays(1)
                },
                new() { Id = 8, TasklistId = 5, Description = "Watch movie", DueDate = DateTime.UtcNow.AddDays(2) },
                new() { Id = 9, TasklistId = 1, Description = "Buy fruit", DueDate = DateTime.UtcNow },
                new() { Id = 10, TasklistId = 1, Description = "Call mom", DueDate = DateTime.UtcNow },
                new() { Id = 11, TasklistId = 1, Description = "Clean kitchen", DueDate = DateTime.UtcNow },
                new() { Id = 12, TasklistId = 2, Description = "Buy vegetables", DueDate = DateTime.UtcNow },
                new() { Id = 13, TasklistId = 3, Description = "Check emails", DueDate = DateTime.UtcNow },
                new() { Id = 14, TasklistId = 4, Description = "Water plants", DueDate = DateTime.UtcNow },
                new() { Id = 15, TasklistId = 5, Description = "Read a book", DueDate = DateTime.UtcNow },
                new() { Id = 16, TasklistId = 6, Description = "Schedule dentist appointment", DueDate = null },
                new() { Id = 17, TasklistId = 6, Description = "Book a vacation", DueDate = null },
                new() { Id = 18, TasklistId = 7, Description = "Organize files", DueDate = null },
                new() { Id = 19, TasklistId = 7, Description = "Clean garage", DueDate = null },
                new() { Id = 20, TasklistId = 8, Description = "Buy new shoes", DueDate = null },
                new() { Id = 21, TasklistId = 8, Description = "Update resume", DueDate = null },
                new() { Id = 22, TasklistId = 9, Description = "Buy eggs", DueDate = DateTime.UtcNow.AddDays(1) },
                new() { Id = 23, TasklistId = 9, Description = "Buy bread", DueDate = DateTime.UtcNow.AddDays(2) },
                new()
                {
                    Id = 24, TasklistId = 10, Description = "Pay internet bill", DueDate = DateTime.UtcNow.AddDays(1)
                },
                new() { Id = 25, TasklistId = 11, Description = "Buy fruits", DueDate = DateTime.UtcNow.AddDays(2) },
                new()
                {
                    Id = 26, TasklistId = 12, Description = "Buy vegetables", DueDate = DateTime.UtcNow.AddDays(1)
                },
                new()
                {
                    Id = 27, TasklistId = 13, Description = "Pay mobile bill", DueDate = DateTime.UtcNow.AddDays(1)
                },
                new()
                {
                    Id = 28, TasklistId = 14, Description = "Plan weekend activities",
                    DueDate = DateTime.UtcNow.AddDays(2)
                }
            };

            foreach (var item in items)
            {
                item.IsCompleted = random.NextDouble() < 0.5;
            }

            context.TaskListItems.AddRange(items);
            await context.SaveChangesAsync();
        }


        private static async Task SeedUserTaskListCategories(AppDbContext context)
        {
            context.UserTaskListCategories.AddRange(
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
            await context.SaveChangesAsync();
        }

        private static async Task SeedFavoriteTaskLists(AppDbContext context)
        {
            var random = new Random();

            var demoUserIds = new[] { demoUser1Id, demoUser2Id, demoUser3Id };

            foreach (var userId in demoUserIds)
            {
                var userTaskLists = await context.TaskLists
                    .Where(tl => tl.CreatedById == userId)
                    .ToListAsync();

                var shuffled = userTaskLists.OrderBy(_ => random.Next()).ToList();
                var countToFavorite = shuffled.Count / 2;

                var favorites = shuffled
                    .Take(countToFavorite)
                    .Select(tl => new FavoriteTaskList
                    {
                        UserId = userId,
                        TaskListId = tl.Id
                    });

                context.FavoriteTaskLists.AddRange(favorites);
            }

            await context.SaveChangesAsync();
        }
    }
}