using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sprout.Api.Domain.Entities;
using Sprout.Api.Domain.Enums;
using Sprout.Domain.Enums;

namespace Sprout.Api.Infrastructure.Persistence.Seeding;

public class TaskListMemberSeeder : IEntityTypeConfiguration<TaskListMember>
{
    public void Configure(EntityTypeBuilder<TaskListMember> builder)
    {
        var demoUser1Id = "1b503418-dc0f-4187-93c0-2e30070b2835";
        var demoUser2Id = "9e22a16c-da04-4232-b479-95c3a7b89259";
        var demoUser3Id = "40fcec36-7eef-42d8-8086-cd2226b88d00";

        builder.HasData(
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
    }
}