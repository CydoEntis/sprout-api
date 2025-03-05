namespace TaskGarden.Application.Common.Models;

public class ListItemOrder
{
    public int Id { get; set; }
    public int TaskListId { get; set; }
    public int Position { get; set; }
}