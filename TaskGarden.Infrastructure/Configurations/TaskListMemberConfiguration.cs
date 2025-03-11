using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Configurations;

public class TaskListMemberConfiguration : IEntityTypeConfiguration<TaskListMember>
{
    public void Configure(EntityTypeBuilder<TaskListMember> builder)
    {
        builder.HasKey(ut => new { ut.UserId, ut.TaskListId });

        builder.HasOne(ut => ut.User)
            .WithMany(u => u.TaskListMembers)
            .HasForeignKey(ut => ut.UserId);

        builder.HasOne(ut => ut.TaskList)
            .WithMany(t => t.TaskListAssignments)
            .HasForeignKey(ut => ut.TaskListId);
    }
}