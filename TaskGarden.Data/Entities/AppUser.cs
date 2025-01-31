using Microsoft.AspNetCore.Identity;

namespace TaskGarden.Data.Models;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Category> Categories { get; set; }
    public ICollection<TaskListAssignments> UserTaskLists { get; set; }
}