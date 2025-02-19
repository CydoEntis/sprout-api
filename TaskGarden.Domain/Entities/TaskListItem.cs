using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Domain.Entities;

public class TaskListItem : BaseEntity
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int TaskListId { get; set; }
    [ForeignKey("TaskListId")]
    public TaskList TaskList { get; set; }
    public string CompletedById { get; set; }
    [ForeignKey("CompletedById")]
    public AppUser CompletedBy { get; set; }
}