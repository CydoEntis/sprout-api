using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Domain.Common;

namespace TaskGarden.Api.Infrastructure.Persistence.Seeding;

public class CategorySeeder : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var demoUser1Id = "1b503418-dc0f-4187-93c0-2e30070b2835";
        var demoUser2Id = "9e22a16c-da04-4232-b479-95c3a7b89259";
        var demoUser3Id = "40fcec36-7eef-42d8-8086-cd2226b88d00";

        builder.HasData(
            // Demo User 1 Categories
            new Category
            {
                Id = 1,
                Name = "Groceries",
                Tag = CategoryIcon.ShoppingCart.Tag,
                Color = "lime",
                UserId = demoUser1Id
            },
            new Category
            {
                Id = 2,
                Name = "Bills",
                Tag = CategoryIcon.Banknote.Tag,
                Color = "red",
                UserId = demoUser1Id
            },
            new Category
            {
                Id = 3,
                Name = "Entertainment",
                Tag = CategoryIcon.RollerCoaster.Tag,
                Color = "blue",
                UserId = demoUser1Id
            },
            new Category
            {
                Id = 4,
                Name = "Travel",
                Tag = CategoryIcon.Plane.Tag,
                Color = "yellow",
                UserId = demoUser1Id
            },
            new Category
            {
                Id = 5,
                Name = "School",
                Tag = CategoryIcon.University.Tag,
                Color = "grape",
                UserId = demoUser1Id
            },

            // Demo User 2 Categories
            new Category
            {
                Id = 6,
                Name = "Groceries",
                Tag = CategoryIcon.ShoppingCart.Tag,
                Color = "cyan",
                UserId = demoUser2Id
            },
            new Category
            {
                Id = 7,
                Name = "Bills",
                Tag = CategoryIcon.Receipt.Tag,
                Color = "orange",
                UserId = demoUser2Id
            },

            // Demo User 3 Categories
            new Category
            {
                Id = 8,
                Name = "Groceries",
                Tag = CategoryIcon.ShoppingBasket.Tag,
                Color = "indigo",
                UserId = demoUser3Id
            },
            new Category
            {
                Id = 9,
                Name = "Bills",
                Tag = CategoryIcon.HandCoins.Tag,
                Color = "teal",
                UserId = demoUser3Id
            },
            new Category
            {
                Id = 10,
                Name = "Entertainment",
                Tag = CategoryIcon.Theater.Tag,
                Color = "pink",
                UserId = demoUser3Id
            }
        );
    }
}