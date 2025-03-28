using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Api.Domain.Entities;

public class Tasklist : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public string CreatedById { get; set; }
    [ForeignKey("CreatedById")]
    public AppUser CreatedBy { get; set; }
    public ICollection<TaskListMember> TaskListMembers { get; set; } = new HashSet<TaskListMember>();
    public ICollection<TasklistItem> TaskListItems { get; set; } = new List<TasklistItem>();
    public bool IsCompleted { get; set; } = false;

    public ICollection<UserTasklistCategory> UserCategories { get; set; } = new List<UserTasklistCategory>();
}