﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Seeders;

public class UserSeeder : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();

        var users = new List<AppUser>
        {
            new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Demo",
                LastName = "One",
                Email = "demo1@demo.com",
                UserName = "demo1@demo.com",
                NormalizedEmail = "DEMO1@DEMO.COM",
                NormalizedUserName = "DEMO1@DEMO.COM",
                PasswordHash = hasher.HashPassword(null, "Demo@123")
            },
            new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Demo",
                LastName = "Two",
                Email = "demo2@demo.com",
                UserName = "demo2@demo.com",
                NormalizedEmail = "DEMO2@DEMO.COM",
                NormalizedUserName = "DEMO2@DEMO.COM",
                PasswordHash = hasher.HashPassword(null, "Demo@123")
            },
            new AppUser
            {
                Id = Guid.NewGuid().ToString(),
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