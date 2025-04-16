using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sprout.Api.Domain.Entities;

namespace Sprout.Api.Infrastructure.Persistence.Seeding;

public class TaskListSeeder : IEntityTypeConfiguration<TaskList>
{
    public void Configure(EntityTypeBuilder<TaskList> builder)
    {
        var demoUser1Id = "1b503418-dc0f-4187-93c0-2e30070b2835";
        var demoUser2Id = "9e22a16c-da04-4232-b479-95c3a7b89259";
        var demoUser3Id = "40fcec36-7eef-42d8-8086-cd2226b88d00";

        builder.HasData(
            // Demo User 1 Categories
            new TaskList
            {
                Id = 1,
                Name = "ShopRite shopping list",
                Description = "This week's shopping list for ShopRite",
                CreatedById = demoUser1Id,
            },
            new TaskList
            {
                Id = 2,
                Name = "Walmart shopping list",
                Description = "This week's shopping list for Walmart",
                CreatedById = demoUser1Id,
            },
            new TaskList
            {
                Id = 3,
                Name = "Rent payment",
                Description = "Monthly rent payment reminders",
                CreatedById = demoUser1Id,
            },
            new TaskList
            {
                Id = 4,
                Name = "Electricity Bill",
                Description = "Electricity bill payment reminders",
                CreatedById = demoUser1Id,
            },
            new TaskList
            {
                Id = 5,
                Name = "Movie night",
                Description = "List of movies to watch this weekend",
                CreatedById = demoUser1Id,
            },
            new TaskList
            {
                Id = 6,
                Name = "Concert Tickets",
                Description = "Track upcoming concerts and events",
                CreatedById = demoUser1Id,
            },
            new TaskList
            {
                Id = 7,
                Name = "Vacation Planning",
                Description = "Plan and book flights and hotels",
                CreatedById = demoUser1Id,
            },
            new TaskList
            {
                Id = 8,
                Name = "Assignment Deadlines",
                Description = "Track deadlines for assignments",
                CreatedById = demoUser1Id,
            },

            // Demo User 2 Categories
            new TaskList
            {
                Id = 9,
                Name = "Giant shopping list",
                Description = "Weekly shopping list for Giant",
                CreatedById = demoUser2Id,
            },
            new TaskList
            {
                Id = 10,
                Name = "Internet Bill",
                Description = "Track Internet bill payments",
                CreatedById = demoUser2Id,
            },

            // Demo User 3 Categories
            new TaskList
            {
                Id = 11,
                Name = "SuperMart shopping list",
                Description = "Grocery list for SuperMart",
                CreatedById = demoUser3Id,
            },
            new TaskList
            {
                Id = 12,
                Name = "Local Market shopping list",
                Description = "List of items for the local market",
                CreatedById = demoUser3Id,
            },
            new TaskList
            {
                Id = 13,
                Name = "Mobile Bill",
                Description = "Keep track of monthly mobile bills",
                CreatedById = demoUser3Id,
            },
            new TaskList
            {
                Id = 14,
                Name = "Weekend Fun Activities",
                Description = "List of fun things to do this weekend",
                CreatedById = demoUser3Id,
            }
        );

    }
}