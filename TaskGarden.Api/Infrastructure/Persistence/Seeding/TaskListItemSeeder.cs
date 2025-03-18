using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Seeders
{
    public class TaskListItemSeeder : IEntityTypeConfiguration<TaskListItem>
    {
        public void Configure(EntityTypeBuilder<TaskListItem> builder)
        {
            var demoUser1Id = "1b503418-dc0f-4187-93c0-2e30070b2835";
            var demoUser2Id = "9e22a16c-da04-4232-b479-95c3a7b89259";
            var demoUser3Id = "40fcec36-7eef-42d8-8086-cd2226b88d00";

            builder.HasData(
                // TaskListId = 1 (ShopRite shopping list)
                new TaskListItem { Id = 1, Description = "Buy apples", IsCompleted = false, Position = 1, TaskListId = 1 },
                new TaskListItem { Id = 2, Description = "Buy bananas", IsCompleted = true, Position = 2, TaskListId = 1, CompletedById = demoUser1Id },
                new TaskListItem { Id = 3, Description = "Buy oranges", IsCompleted = false, Position = 3, TaskListId = 1 },
                new TaskListItem { Id = 4, Description = "Buy milk", IsCompleted = true, Position = 4, TaskListId = 1, CompletedById = demoUser1Id },
                new TaskListItem { Id = 5, Description = "Buy eggs", IsCompleted = false, Position = 5, TaskListId = 1 },

                // TaskListId = 2 (Walmart shopping list)
                new TaskListItem { Id = 6, Description = "Buy toothpaste", IsCompleted = true, Position = 1, TaskListId = 2, CompletedById = demoUser1Id },
                new TaskListItem { Id = 7, Description = "Buy toothbrush", IsCompleted = false, Position = 2, TaskListId = 2 },
                new TaskListItem { Id = 8, Description = "Buy shampoo", IsCompleted = false, Position = 3, TaskListId = 2 },
                new TaskListItem { Id = 9, Description = "Buy conditioner", IsCompleted = true, Position = 4, TaskListId = 2, CompletedById = demoUser1Id },
                new TaskListItem { Id = 10, Description = "Buy soap", IsCompleted = false, Position = 5, TaskListId = 2 },

                // TaskListId = 3 (Rent payment)
                new TaskListItem { Id = 11, Description = "Pay rent", IsCompleted = false, Position = 1, TaskListId = 3 },
                new TaskListItem { Id = 12, Description = "Confirm payment", IsCompleted = true, Position = 2, TaskListId = 3, CompletedById = demoUser1Id },

                // TaskListId = 4 (Electricity Bill)
                new TaskListItem { Id = 13, Description = "Pay electricity bill", IsCompleted = false, Position = 1, TaskListId = 4 },
                new TaskListItem { Id = 14, Description = "Check bill amount", IsCompleted = true, Position = 2, TaskListId = 4, CompletedById = demoUser1Id },

                // TaskListId = 5 (Movie night)
                new TaskListItem { Id = 15, Description = "Buy popcorn", IsCompleted = false, Position = 1, TaskListId = 5 },
                new TaskListItem { Id = 16, Description = "Pick movie", IsCompleted = true, Position = 2, TaskListId = 5, CompletedById = demoUser1Id },
                new TaskListItem { Id = 17, Description = "Prepare snacks", IsCompleted = false, Position = 3, TaskListId = 5 },

                // TaskListId = 6 (Concert Tickets)
                new TaskListItem { Id = 18, Description = "Buy concert tickets", IsCompleted = false, Position = 1, TaskListId = 6 },
                new TaskListItem { Id = 19, Description = "Confirm concert date", IsCompleted = true, Position = 2, TaskListId = 6, CompletedById = demoUser1Id },

                // TaskListId = 7 (Vacation Planning)
                new TaskListItem { Id = 20, Description = "Book flights", IsCompleted = true, Position = 1, TaskListId = 7, CompletedById = demoUser1Id },
                new TaskListItem { Id = 21, Description = "Reserve hotel", IsCompleted = false, Position = 2, TaskListId = 7 },
                new TaskListItem { Id = 22, Description = "Plan itinerary", IsCompleted = false, Position = 3, TaskListId = 7 },

                // TaskListId = 8 (Assignment Deadlines)
                new TaskListItem { Id = 23, Description = "Submit math assignment", IsCompleted = false, Position = 1, TaskListId = 8 },
                new TaskListItem { Id = 24, Description = "Submit history assignment", IsCompleted = true, Position = 2, TaskListId = 8, CompletedById = demoUser1Id },

                // TaskListId = 9 (Giant shopping list)
                new TaskListItem { Id = 25, Description = "Buy bread", IsCompleted = true, Position = 1, TaskListId = 9, CompletedById = demoUser2Id },
                new TaskListItem { Id = 26, Description = "Buy butter", IsCompleted = false, Position = 2, TaskListId = 9 },

                // TaskListId = 10 (Internet Bill)
                new TaskListItem { Id = 27, Description = "Pay internet bill", IsCompleted = true, Position = 1, TaskListId = 10, CompletedById = demoUser2Id },

                // TaskListId = 11 (SuperMart shopping list)
                new TaskListItem { Id = 28, Description = "Buy sugar", IsCompleted = false, Position = 1, TaskListId = 11 },
                new TaskListItem { Id = 29, Description = "Buy rice", IsCompleted = true, Position = 2, TaskListId = 11, CompletedById = demoUser3Id },

                // TaskListId = 12 (Local Market shopping list)
                new TaskListItem { Id = 30, Description = "Buy tomatoes", IsCompleted = true, Position = 1, TaskListId = 12, CompletedById = demoUser3Id },

                // TaskListId = 13 (Mobile Bill)
                new TaskListItem { Id = 31, Description = "Pay mobile bill", IsCompleted = false, Position = 1, TaskListId = 13 },

                // TaskListId = 14 (Weekend Fun Activities)
                new TaskListItem { Id = 32, Description = "Plan weekend trip", IsCompleted = false, Position = 1, TaskListId = 14 },
                new TaskListItem { Id = 33, Description = "Book tickets", IsCompleted = true, Position = 2, TaskListId = 14, CompletedById = demoUser3Id }
            );
        }
    }
}
