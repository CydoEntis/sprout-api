namespace Sprout.Api.Application.Shared.Models;

public class TasklistItemResponse
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int TaskListId { get; set; }
    public int Position { get; set; }
}