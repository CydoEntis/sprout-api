using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Configurations;

public class UserTaskListCategoryConfiguration : IEntityTypeConfiguration<UserTaskListCategory>
{
    public void Configure(EntityTypeBuilder<UserTaskListCategory> builder)
    {
        // Composite key for UserTaskListCategory
        builder.HasKey(ut => new { ut.UserId, ut.TaskListId });

        builder.HasOne(ut => ut.User)
            .WithMany(u => u.UserTaskListCategories)
            .HasForeignKey(ut => ut.UserId);

        builder.HasOne(ut => ut.TaskList)
            .WithMany(tl => tl.UserCategories)
            .HasForeignKey(ut => ut.TaskListId);

        builder.HasOne(ut => ut.Category)
            .WithMany(c => c.UserTaskListCategories)
            .HasForeignKey(ut => ut.CategoryId);
    }
}