using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Domain.Entities;

public class TaskListItem : BaseEntity
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public required int TaskListId { get; set; }
    [ForeignKey("TaskListId")]
    public required TaskList TaskList { get; set; }
    public string? CompletedById { get; set; } = string.Empty;
    [ForeignKey("CompletedById")]
    public AppUser? CompletedBy { get; set; }
}