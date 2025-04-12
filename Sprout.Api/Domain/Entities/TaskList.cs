using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Api.Domain.Entities;

public class TaskList : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public string CreatedById { get; set; }
    [ForeignKey("CreatedById")] public AppUser CreatedBy { get; set; }
    public ICollection<TaskListMember> TaskListMembers { get; set; } = new HashSet<TaskListMember>();
    public ICollection<TaskListItem> TaskListItems { get; set; } = new List<TaskListItem>();
    public bool IsCompleted { get; set; } = false;

    public ICollection<UserTaskListCategory> UserCategories { get; set; } = new List<UserTaskListCategory>();
}