using Microsoft.AspNetCore.Identity;

namespace Sprout.Api.Domain.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<UserTaskListCategory> UserTaskListCategories { get; set; } = new List<UserTaskListCategory>();

    public ICollection<TaskListMember> TaskListMembers { get; set; }
}