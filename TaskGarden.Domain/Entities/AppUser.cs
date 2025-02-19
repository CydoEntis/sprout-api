using Microsoft.AspNetCore.Identity;

namespace TaskGarden.Domain.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Category> Categories { get; set; }
    public ICollection<TaskListAssignments> TaskListAssignments { get; set; }
}