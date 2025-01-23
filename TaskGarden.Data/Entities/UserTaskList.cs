using TaskGarden.Data.Enums;

namespace TaskGarden.Data.Models;

public class UserTaskList : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public int TaskListId { get; set; }
    public TaskList TaskList { get; set; }
    public string Role { get; set; }

    public void SetRole(string role)
    {
        if (Enum.TryParse(role, out TaskListRole roleValue))
        {
            Role = roleValue.ToString();
        }
    }

    public TaskListRole GetRole()
    {
        return (TaskListRole)Enum.Parse(typeof(TaskListRole), Role);
    }
}