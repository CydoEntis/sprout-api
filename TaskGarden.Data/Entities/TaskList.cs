using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Data.Models;

public class TaskList : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public string CreatedById { get; set; }
    [ForeignKey("CreatedById")]
    public AppUser CreatedBy { get; set; }
    public ICollection<TaskListAssignments> TaskListAssignments { get; set; }
    public ICollection<TaskListItem> TaskListItems { get; set; } = new List<TaskListItem>();
    
    public int CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
    
}