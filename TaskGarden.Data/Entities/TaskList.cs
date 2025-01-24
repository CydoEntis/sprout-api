using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Data.Models;

public class TaskList : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public AppUser User { get; set; }
    public ICollection<UserTaskList> UserTaskLists { get; set; }
    public ICollection<TaskListItem> TaskListItems { get; set; } = new List<TaskListItem>();
    
    public int CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
    
}