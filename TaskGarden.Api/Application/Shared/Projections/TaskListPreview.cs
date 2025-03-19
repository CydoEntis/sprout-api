using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Projections;

public class TaskListPreview
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CompletedTasksCount { get; set; }
    public int TotalTasksCount { get; set; }
    public bool IsCompleted { get; set; }
    public string? CategoryName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int TaskCompletionPercentage { get; set; }
    public List<Member> Members { get; set; } = new List<Member>();
    public List<TaskListItemDetail> TaskListItems { get; set; } = new List<TaskListItemDetail>();
}