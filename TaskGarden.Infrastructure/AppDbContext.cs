using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Configurations;
using TaskGarden.Infrastructure.Seeders;

namespace TaskGarden.Infrastructure;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }

    public DbSet<TaskListItem> TaskListItems { get; set; }
    public DbSet<TaskListMember> TaskListMembers { get; set; }

    public DbSet<Invitation> Invitations { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserSeeder());  
        builder.ApplyConfiguration(new CategorySeeder());  

        builder.ApplyConfiguration(new TaskListMemberConfiguration()); 
        builder.ApplyConfiguration(new InvitationConfiguration()); 
        builder.ApplyConfiguration(new AppUserConfiguration()); 
        
        
    }
}