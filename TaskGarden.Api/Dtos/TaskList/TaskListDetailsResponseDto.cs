namespace TaskGarden.Api.Dtos.TaskList;

public class TaskListDetailsResponseDto
{
    public string Name { get; set; }
    public int CompletedTasksCount { get; set; }
    public int TotalTasks { get; set; }
    public bool IsCompleted { get; set; }
    public List<MemberResponseDto> Members { get; set; } = new List<MemberResponseDto>();
    public List<TaskListItemReponseDto> TaskListItems { get; set; } = new List<TaskListItemReponseDto>();
}