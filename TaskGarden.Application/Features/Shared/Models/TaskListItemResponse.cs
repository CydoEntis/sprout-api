namespace TaskGarden.Application.Features.Shared.Models;

public class TaskListItemResponse
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}