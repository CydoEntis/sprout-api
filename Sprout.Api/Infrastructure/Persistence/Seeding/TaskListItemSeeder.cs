using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sprout.Api.Domain.Entities;
using System;

namespace Sprout.Api.Infrastructure.Persistence.Seeding
{
    public class TaskListItemSeeder : IEntityTypeConfiguration<TaskListItem>
    {
        public void Configure(EntityTypeBuilder<TaskListItem> builder)
        {
            var demoUser1Id = "1b503418-dc0f-4187-93c0-2e30070b2835";
            var demoUser2Id = "9e22a16c-da04-4232-b479-95c3a7b89259";
            var demoUser3Id = "40fcec36-7eef-42d8-8086-cd2226b88d00";

            var random = new Random();
            var today = DateTime.UtcNow.Date;

            builder.HasData(
                // TaskListId = 1 (ShopRite shopping list)
                new TaskListItem
                {
                    Id = 1, Description = "Buy apples", IsCompleted = random.NextDouble() < 0.5, Position = 1,
                    TasklistId = 1,
                    DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 2, Description = "Buy bananas", IsCompleted = random.NextDouble() < 0.5, Position = 2,
                    TasklistId = 1,
                    CompletedById = demoUser1Id, DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 3, Description = "Buy oranges", IsCompleted = random.NextDouble() < 0.5, Position = 3,
                    TasklistId = 1,
                    DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 4, Description = "Buy milk", IsCompleted = random.NextDouble() < 0.5, Position = 4,
                    TasklistId = 1,
                    CompletedById = demoUser1Id, DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 5, Description = "Buy eggs", IsCompleted = random.NextDouble() < 0.5, Position = 5,
                    TasklistId = 1,
                    DueDate = GenerateDueDate(today, random)
                },

                // TaskListId = 2 (Walmart shopping list)
                new TaskListItem
                {
                    Id = 6, Description = "Buy toothpaste", IsCompleted = random.NextDouble() < 0.5, Position = 1,
                    TasklistId = 2,
                    CompletedById = demoUser1Id, DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 7, Description = "Buy toothbrush", IsCompleted = random.NextDouble() < 0.5, Position = 2,
                    TasklistId = 2,
                    DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 8, Description = "Buy shampoo", IsCompleted = random.NextDouble() < 0.5, Position = 3,
                    TasklistId = 2,
                    DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 9, Description = "Buy conditioner", IsCompleted = random.NextDouble() < 0.5, Position = 4,
                    TasklistId = 2,
                    CompletedById = demoUser1Id, DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 10, Description = "Buy soap", IsCompleted = random.NextDouble() < 0.5, Position = 5,
                    TasklistId = 2,
                    DueDate = GenerateDueDate(today, random)
                },

                // TaskListId = 3 (Rent payment)
                new TaskListItem
                {
                    Id = 11, Description = "Pay rent", IsCompleted = random.NextDouble() < 0.5, Position = 1,
                    TasklistId = 3,
                    DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 12, Description = "Confirm payment", IsCompleted = random.NextDouble() < 0.5, Position = 2,
                    TasklistId = 3,
                    CompletedById = demoUser1Id, DueDate = GenerateDueDate(today, random)
                },

                // TaskListId = 4 (Electricity Bill)
                new TaskListItem
                {
                    Id = 13, Description = "Pay electricity bill", IsCompleted = random.NextDouble() < 0.5,
                    Position = 1, TasklistId = 4,
                    DueDate = GenerateDueDate(today, random)
                },
                new TaskListItem
                {
                    Id = 14, Description = "Check bill amount", IsCompleted = random.NextDouble() < 0.5, Position = 2,
                    TasklistId = 4,
                    CompletedById = demoUser1Id, DueDate = GenerateDueDate(today, random)
                }
            );
        }

        private DateTime? GenerateDueDate(DateTime today, Random random)
        {
            double dueDateChance = random.NextDouble();
            if (dueDateChance < 0.4)
            {
                // 40% chance to be due today
                return today;
            }
            else if (dueDateChance < 0.8)
            {
                // 40% chance to be due within 2 weeks
                return today.AddDays(random.Next(1, 15)); // Random date between 1 to 14 days from today
            }
            else
            {
                // 20% chance to have no due date
                return null;
            }
        }
    }
}