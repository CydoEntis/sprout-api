using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Infrastructure.Persistence.Seeding;

public class UserSeeder : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();

        var users = new List<AppUser>
        {
            new()
            {
                Id = "1b503418-dc0f-4187-93c0-2e30070b2835",
                FirstName = "Demo",
                LastName = "One",
                Email = "demo1@demo.com",
                UserName = "demo1@demo.com",
                NormalizedEmail = "DEMO1@DEMO.COM",
                NormalizedUserName = "DEMO1@DEMO.COM",
                PasswordHash = hasher.HashPassword(null, "Demo@123")
            },
            new()
            {
                Id = "9e22a16c-da04-4232-b479-95c3a7b89259",
                FirstName = "Demo",
                LastName = "Two",
                Email = "demo2@demo.com",
                UserName = "demo2@demo.com",
                NormalizedEmail = "DEMO2@DEMO.COM",
                NormalizedUserName = "DEMO2@DEMO.COM",
                PasswordHash = hasher.HashPassword(null, "Demo@123")
            },
            new()
            {
                Id = "40fcec36-7eef-42d8-8086-cd2226b88d00",
                FirstName = "Demo",
                LastName = "Three",
                Email = "demo3@demo.com",
                UserName = "demo3@demo.com",
                NormalizedEmail = "DEMO3@DEMO.COM",
                NormalizedUserName = "DEMO3@DEMO.COM",
                PasswordHash = hasher.HashPassword(null, "Demo@123")
            }
        };

        builder.HasData(users);
    }
}