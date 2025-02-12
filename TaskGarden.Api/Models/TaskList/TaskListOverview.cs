namespace TaskGarden.Data.Models.TaskList;

public class TaskListOverview
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Member.Member> Members { get; set; }
    public int TotalTasksCount { get; set; }
    public int CompletedTasksCount { get; set; }
    public double TaskCompletionPercentage { get; set; }
    
}