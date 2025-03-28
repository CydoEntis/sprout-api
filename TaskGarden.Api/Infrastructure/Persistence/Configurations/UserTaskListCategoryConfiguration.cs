using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Infrastructure.Persistence.Configurations;

public class UserTaskListCategoryConfiguration : IEntityTypeConfiguration<UserTasklistCategory>
{
    public void Configure(EntityTypeBuilder<UserTasklistCategory> builder)
    {
        builder.Ignore(utc => utc.Id);

        builder.HasKey(utc => new { utc.UserId, utc.CategoryId, utc.TaskListId });

        builder.HasOne(utc => utc.User)
            .WithMany(u => u.UserTaskListCategories)
            .HasForeignKey(utc => utc.UserId);

        builder.HasOne(utc => utc.Tasklist)
            .WithMany(tl => tl.UserCategories)
            .HasForeignKey(utc => utc.TaskListId)
            .IsRequired(false);

        builder.HasOne(utc => utc.Category)
            .WithMany(c => c.UserTaskListCategories)
            .HasForeignKey(utc => utc.CategoryId);
    }
}