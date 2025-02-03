namespace TaskGarden.Api.Dtos.TaskList;

public class TaskListDetailsReponseDto
{
    public string Name { get; set; }
    public int CompletedTasks { get; set; }
    public int TotalTasks { get; set; }
    public bool IsCompleted { get; set; }
    public List<TaskListItemReponseDto> TaskListItems { get; set; } = new List<TaskListItemReponseDto>();
}