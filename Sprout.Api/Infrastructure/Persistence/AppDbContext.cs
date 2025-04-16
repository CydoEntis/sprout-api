using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Domain.Entities;
using Sprout.Api.Infrastructure.Persistence.Configurations;
using Sprout.Api.Infrastructure.Persistence.Seeding;

namespace Sprout.Api.Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }
    public DbSet<UserTaskListCategory> UserTaskListCategories { get; set; }


    public DbSet<TaskListItem> TaskListItems { get; set; }
    public DbSet<TaskListMember> TaskListMembers { get; set; }

    public DbSet<Invitation> Invitations { get; set; }

    public DbSet<FavoriteTaskList> FavoriteTaskLists { get; set; }


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