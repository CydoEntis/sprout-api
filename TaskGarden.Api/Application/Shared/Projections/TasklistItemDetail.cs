namespace TaskGarden.Api.Application.Shared.Projections;

public class TasklistItemDetail
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int Position { get; set; }
    public DateTime? DueDate { get; set; } // <-- Add DueDate here for the response
}