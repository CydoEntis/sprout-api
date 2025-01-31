using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Models;

namespace TaskGarden.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }

    public DbSet<TaskListAssignments> TaskListAssignments { get; set; }
    public DbSet<TaskListItem> TaskListItems { get; set; }

    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TaskListAssignments>()
            .HasKey(ut => new { ut.UserId, ut.TaskListId });

        builder.Entity<TaskListAssignments>()
            .HasOne(ut => ut.User)
            .WithMany(u => u.TaskListAssignments)
            .HasForeignKey(ut => ut.UserId);

        builder.Entity<TaskListAssignments>()
            .HasOne(ut => ut.TaskList)
            .WithMany(t => t.TaskListAssignments)
            .HasForeignKey(ut => ut.TaskListId);
        
        // TODO: Add database seeding.
    }
}