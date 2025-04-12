using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Infrastructure.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasMany(u => u.TaskListMembers)
            .WithOne(ut => ut.User)
            .HasForeignKey(ut => ut.UserId);
    }
}