using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Data.Models;

public class TaskList : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public AppUser User { get; set; }
    
    public ICollection<UserTaskList> UserTaskLists { get; set; }

}