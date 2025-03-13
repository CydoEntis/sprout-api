using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;

namespace TaskGarden.Infrastructure.Seeders;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                TaskListId = 1,
                UserId = demoUser1Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 2,
                TaskListId = 2,
                UserId = demoUser1Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 3,
                TaskListId = 3,
                UserId = demoUser1Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 4,
                TaskListId = 4,
                UserId = demoUser1Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 5,
                TaskListId = 5,
                UserId = demoUser1Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 6,
                TaskListId = 6,
                UserId = demoUser1Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 7,
                TaskListId = 7,
                UserId = demoUser1Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 8,
                TaskListId = 8,
                UserId = demoUser1Id,
                Role = TaskListRole.Owner
            },
            // Owner is Demo User 2
            new TaskListMember
            {
                Id = 9,
                TaskListId = 9,
                UserId = demoUser2Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 10,
                TaskListId = 10,
                UserId = demoUser2Id,
                Role = TaskListRole.Owner
            },
            // Owner is Demo User 3
            new TaskListMember
            {
                Id = 11,
                TaskListId = 11,
                UserId = demoUser3Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 12,
                TaskListId = 12,
                UserId = demoUser3Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 13,
                TaskListId = 13,
                UserId = demoUser3Id,
                Role = TaskListRole.Owner
            },
            new TaskListMember
            {
                Id = 14,
                TaskListId = 14,
                UserId = demoUser3Id,
                Role = TaskListRole.Owner
            },
            // Adding Additional Members
            new TaskListMember
            {
                Id = 15,
                TaskListId = 1,
                UserId = demoUser2Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 16,
                TaskListId = 2,
                UserId = demoUser2Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 17,
                TaskListId = 3,
                UserId = demoUser2Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 18,
                TaskListId = 4,
                UserId = demoUser2Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 19,
                TaskListId = 5,
                UserId = demoUser2Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 20,
                TaskListId = 6,
                UserId = demoUser2Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 21,
                TaskListId = 7,
                UserId = demoUser2Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 22,
                TaskListId = 8,
                UserId = demoUser2Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 23,
                TaskListId = 9,
                UserId = demoUser3Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 24,
                TaskListId = 10,
                UserId = demoUser3Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 25,
                TaskListId = 11,
                UserId = demoUser1Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 26,
                TaskListId = 12,
                UserId = demoUser1Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 27,
                TaskListId = 13,
                UserId = demoUser1Id,
                Role = TaskListRole.Viewer
            },
            new TaskListMember
            {
                Id = 28,
                TaskListId = 14,
                UserId = demoUser1Id,
                Role = TaskListRole.Viewer
            }
        );
    }
}