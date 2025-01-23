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

    public DbSet<UserTaskList> UserTaskLists { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserTaskList>()
            .HasKey(ut => new { ut.UserId, ut.TaskListId });

        builder.Entity<UserTaskList>()
            .HasOne(ut => ut.User)
            .WithMany(u => u.UserTaskLists)
            .HasForeignKey(ut => ut.UserId);

        builder.Entity<UserTaskList>()
            .HasOne(ut => ut.TaskList)
            .WithMany(t => t.UserTaskLists)
            .HasForeignKey(ut => ut.TaskListId);
        
        // TODO: Add database seeding.
    }
}