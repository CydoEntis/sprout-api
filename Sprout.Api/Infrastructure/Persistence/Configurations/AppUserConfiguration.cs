using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sprout.Api.Domain.Entities;

namespace Sprout.Api.Infrastructure.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasMany(u => u.TaskListMembers)
            .WithOne(ut => ut.User)
            .HasForeignKey(ut => ut.UserId);
    }
}