using TaskGarden.Api.Dtos.Category;

namespace TaskGarden.Api.Dtos.TaskList;

public class TaskListResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryResponseDto Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<MemberResponseDto> Members { get; set; }
    public int TotalTasksCount { get; set; }
    public int CompletedTasksCount { get; set; }
    public double TaskCompletionPercentage { get; set; }
}