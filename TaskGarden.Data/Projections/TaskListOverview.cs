using TaskGarden.Data.Models.Member;

namespace TaskGarden.Data.Projections;

public class TaskListOverview
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Member> Members { get; set; }
    public int TotalTasksCount { get; set; }
    public int CompletedTasksCount { get; set; }
    public double TaskCompletionPercentage { get; set; }
    
}