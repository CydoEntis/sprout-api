using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Infrastructure.Persistence.Seeding
{
    public class TaskListItemSeeder : IEntityTypeConfiguration<TasklistItem>
    {
        public void Configure(EntityTypeBuilder<TasklistItem> builder)
        {
            var demoUser1Id = "1b503418-dc0f-4187-93c0-2e30070b2835";
            var demoUser2Id = "9e22a16c-da04-4232-b479-95c3a7b89259";
            var demoUser3Id = "40fcec36-7eef-42d8-8086-cd2226b88d00";

            builder.HasData(
                // TaskListId = 1 (ShopRite shopping list)
                new TasklistItem
                    { Id = 1, Description = "Buy apples", IsCompleted = false, Position = 1, TasklistId = 1 },
                new TasklistItem
                {
                    Id = 2, Description = "Buy bananas", IsCompleted = true, Position = 2, TasklistId = 1,
                    CompletedById = demoUser1Id
                },
                new TasklistItem
                    { Id = 3, Description = "Buy oranges", IsCompleted = false, Position = 3, TasklistId = 1 },
                new TasklistItem
                {
                    Id = 4, Description = "Buy milk", IsCompleted = true, Position = 4, TasklistId = 1,
                    CompletedById = demoUser1Id
                },
                new TasklistItem
                    { Id = 5, Description = "Buy eggs", IsCompleted = false, Position = 5, TasklistId = 1 },

                // TaskListId = 2 (Walmart shopping list)
                new TasklistItem
                {
                    Id = 6, Description = "Buy toothpaste", IsCompleted = true, Position = 1, TasklistId = 2,
                    CompletedById = demoUser1Id
                },
                new TasklistItem
                    { Id = 7, Description = "Buy toothbrush", IsCompleted = false, Position = 2, TasklistId = 2 },
                new TasklistItem
                    { Id = 8, Description = "Buy shampoo", IsCompleted = false, Position = 3, TasklistId = 2 },
                new TasklistItem
                {
                    Id = 9, Description = "Buy conditioner", IsCompleted = true, Position = 4, TasklistId = 2,
                    CompletedById = demoUser1Id
                },
                new TasklistItem
                    { Id = 10, Description = "Buy soap", IsCompleted = false, Position = 5, TasklistId = 2 },

                // TaskListId = 3 (Rent payment)
                new TasklistItem
                    { Id = 11, Description = "Pay rent", IsCompleted = false, Position = 1, TasklistId = 3 },
                new TasklistItem
                {
                    Id = 12, Description = "Confirm payment", IsCompleted = true, Position = 2, TasklistId = 3,
                    CompletedById = demoUser1Id
                },

                // TaskListId = 4 (Electricity Bill)
                new TasklistItem
                {
                    Id = 13, Description = "Pay electricity bill", IsCompleted = false, Position = 1, TasklistId = 4
                },
                new TasklistItem
                {
                    Id = 14, Description = "Check bill amount", IsCompleted = true, Position = 2, TasklistId = 4,
                    CompletedById = demoUser1Id
                },

                // TaskListId = 5 (Movie night)
                new TasklistItem
                    { Id = 15, Description = "Buy popcorn", IsCompleted = false, Position = 1, TasklistId = 5 },
                new TasklistItem
                {
                    Id = 16, Description = "Pick movie", IsCompleted = true, Position = 2, TasklistId = 5,
                    CompletedById = demoUser1Id
                },
                new TasklistItem
                    { Id = 17, Description = "Prepare snacks", IsCompleted = false, Position = 3, TasklistId = 5 },

                // TaskListId = 6 (Concert Tickets)
                new TasklistItem
                    { Id = 18, Description = "Buy concert tickets", IsCompleted = false, Position = 1, TasklistId = 6 },
                new TasklistItem
                {
                    Id = 19, Description = "Confirm concert date", IsCompleted = true, Position = 2, TasklistId = 6,
                    CompletedById = demoUser1Id
                },

                // TaskListId = 7 (Vacation Planning)
                new TasklistItem
                {
                    Id = 20, Description = "Book flights", IsCompleted = true, Position = 1, TasklistId = 7,
                    CompletedById = demoUser1Id
                },
                new TasklistItem
                    { Id = 21, Description = "Reserve hotel", IsCompleted = false, Position = 2, TasklistId = 7 },
                new TasklistItem
                    { Id = 22, Description = "Plan itinerary", IsCompleted = false, Position = 3, TasklistId = 7 },

                // TaskListId = 8 (Assignment Deadlines)
                new TasklistItem
                {
                    Id = 23, Description = "Submit math assignment", IsCompleted = false, Position = 1, TasklistId = 8
                },
                new TasklistItem
                {
                    Id = 24, Description = "Submit history assignment", IsCompleted = true, Position = 2,
                    TasklistId = 8, CompletedById = demoUser1Id
                },

                // TaskListId = 9 (Giant shopping list)
                new TasklistItem
                {
                    Id = 25, Description = "Buy bread", IsCompleted = true, Position = 1, TasklistId = 9,
                    CompletedById = demoUser2Id
                },
                new TasklistItem
                    { Id = 26, Description = "Buy butter", IsCompleted = false, Position = 2, TasklistId = 9 },

                // TaskListId = 10 (Internet Bill)
                new TasklistItem
                {
                    Id = 27, Description = "Pay internet bill", IsCompleted = true, Position = 1, TasklistId = 10,
                    CompletedById = demoUser2Id
                },

                // TaskListId = 11 (SuperMart shopping list)
                new TasklistItem
                    { Id = 28, Description = "Buy sugar", IsCompleted = false, Position = 1, TasklistId = 11 },
                new TasklistItem
                {
                    Id = 29, Description = "Buy rice", IsCompleted = true, Position = 2, TasklistId = 11,
                    CompletedById = demoUser3Id
                },

                // TaskListId = 12 (Local Market shopping list)
                new TasklistItem
                {
                    Id = 30, Description = "Buy tomatoes", IsCompleted = true, Position = 1, TasklistId = 12,
                    CompletedById = demoUser3Id
                },

                // TaskListId = 13 (Mobile Bill)
                new TasklistItem
                    { Id = 31, Description = "Pay mobile bill", IsCompleted = false, Position = 1, TasklistId = 13 },

                // TaskListId = 14 (Weekend Fun Activities)
                new TasklistItem
                    { Id = 32, Description = "Plan weekend trip", IsCompleted = false, Position = 1, TasklistId = 14 },
                new TasklistItem
                {
                    Id = 33, Description = "Book tickets", IsCompleted = true, Position = 2, TasklistId = 14,
                    CompletedById = demoUser3Id
                }
            );
        }
    }
}