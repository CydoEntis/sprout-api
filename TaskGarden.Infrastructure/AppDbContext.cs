using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Configurations;

namespace TaskGarden.Infrastructure;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }

    public DbSet<TaskListMember> TaskListMembers { get; set; }
    public DbSet<TaskListItem> TaskListItems { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new InvitationConfiguration());
        
        builder.Entity<TaskListMember>()
            .HasKey(ut => new { ut.UserId, ut.TaskListId });

        builder.Entity<TaskListMember>()
            .HasOne(ut => ut.User)
            .WithMany(u => u.TaskListMembers)
            .HasForeignKey(ut => ut.UserId);

        builder.Entity<TaskListMember>()
            .HasOne(ut => ut.TaskList)
            .WithMany(t => t.TaskListAssignments)
            .HasForeignKey(ut => ut.TaskListId);

        // TODO: Add database seeding.
    }
}