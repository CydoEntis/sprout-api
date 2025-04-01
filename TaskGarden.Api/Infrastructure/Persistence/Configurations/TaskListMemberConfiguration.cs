using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Infrastructure.Persistence.Configurations;

public class TaskListMemberConfiguration : IEntityTypeConfiguration<TaskListMember>
{
    public void Configure(EntityTypeBuilder<TaskListMember> builder)
    {
        builder.HasKey(ut => new { ut.UserId, TaskListId = ut.TasklistId });

        builder.HasOne(ut => ut.User)
            .WithMany(u => u.TaskListMembers)
            .HasForeignKey(ut => ut.UserId);

        builder.HasOne(ut => ut.Tasklist)
            .WithMany(t => t.TaskListMembers)
            .HasForeignKey(ut => ut.TasklistId);
    }
}