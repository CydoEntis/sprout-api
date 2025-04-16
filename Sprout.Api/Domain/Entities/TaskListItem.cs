using System.ComponentModel.DataAnnotations.Schema;

namespace Sprout.Api.Domain.Entities;

public class TaskListItem : BaseEntity
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public int Position { get; set; }

    public DateTime? DueDate { get; set; }
    public required int TasklistId { get; set; }
    [ForeignKey("TasklistId")] public TaskList TaskList { get; set; }
    public string? CompletedById { get; set; }
    [ForeignKey("CompletedById")] public AppUser? CompletedBy { get; set; }
}