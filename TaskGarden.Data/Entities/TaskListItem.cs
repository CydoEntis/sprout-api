using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Data.Models;

public class TaskListItem : BaseEntity
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int TaskListId { get; set; }
    [ForeignKey("TaskListId")]
    public TaskList TaskList { get; set; }
    public int CompletedById { get; set; }
    [ForeignKey("UserId")]
    public AppUser User { get; set; }
}