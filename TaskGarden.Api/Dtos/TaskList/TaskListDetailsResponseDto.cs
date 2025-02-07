namespace TaskGarden.Api.Dtos.TaskList;

public class TaskListDetailsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CompletedTasksCount { get; set; }
    public int TotalTasksCount { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<MemberResponseDto> Members { get; set; } = new List<MemberResponseDto>();
    public List<TaskListItemReponseDto> TaskListItems { get; set; } = new List<TaskListItemReponseDto>();
}