namespace TaskGarden.Api.Dtos.TaskListItem;

public class TaskListItemResponseDto
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int Order { get; set; }
}