using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Configurations;

public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
{
    public void Configure(EntityTypeBuilder<Invitation> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Status)
            .HasConversion<string>(); 

        builder.HasOne(i => i.TaskList)
            .WithMany()
            .HasForeignKey(i => i.TaskListId);

        builder.HasOne(i => i.InviterUser)
            .WithMany()
            .HasForeignKey(i => i.InviterUserId);
    }
}