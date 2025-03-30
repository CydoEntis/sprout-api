using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Api.Infrastructure.Persistence.Configurations;
using TaskGarden.Api.Infrastructure.Persistence.Seeding;
using TaskGarden.Infrastructure.Configurations;

namespace TaskGarden.Infrastructure;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tasklist> Tasklists { get; set; }
    public DbSet<UserTasklistCategory> UserTasklistCategories { get; set; }


    public DbSet<TasklistItem> TaskListItems { get; set; }
    public DbSet<TaskListMember> TaskListMembers { get; set; }

    public DbSet<Invitation> Invitations { get; set; }

    public DbSet<FavoriteTasklist> FavoriteTasklists { get; set; }

    
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserTaskListCategoryConfiguration());
        builder.ApplyConfiguration(new TaskListMemberConfiguration());
        builder.ApplyConfiguration(new InvitationConfiguration());
        builder.ApplyConfiguration(new AppUserConfiguration());
        
        builder.ApplyConfiguration(new UserSeeder());
        builder.ApplyConfiguration(new CategorySeeder());
        builder.ApplyConfiguration(new TaskListSeeder());
        builder.ApplyConfiguration(new UserTaskListCategorySeeder());
        builder.ApplyConfiguration(new TaskListMemberSeeder());
        builder.ApplyConfiguration(new TaskListItemSeeder());



    }
}