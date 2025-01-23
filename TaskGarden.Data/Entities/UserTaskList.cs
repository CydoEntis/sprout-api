namespace TaskGarden.Data.Models;

public class UserTaskList : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public int TaskListId { get; set; }
    public TaskList TaskList { get; set; }
}