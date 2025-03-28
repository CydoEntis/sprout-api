using Microsoft.AspNetCore.Identity;

namespace TaskGarden.Api.Domain.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<UserTasklistCategory> UserTaskListCategories { get; set; } = new List<UserTasklistCategory>();

    public ICollection<TaskListMember> TaskListMembers { get; set; }
}