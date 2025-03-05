namespace TaskGarden.Infrastructure.Projections;

public class TaskListItemDetail
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int Position { get; set; }
}