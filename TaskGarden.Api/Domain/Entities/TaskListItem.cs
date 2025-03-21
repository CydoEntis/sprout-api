using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Api.Domain.Entities;

public class TaskListItem : BaseEntity
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public int Position { get; set; }
    public required int TaskListId { get; set; }
    [ForeignKey("TaskListId")]
    public TaskList TaskList { get; set; }
    public string? CompletedById { get; set; }
    [ForeignKey("CompletedById")]
    public AppUser? CompletedBy { get; set; }
}