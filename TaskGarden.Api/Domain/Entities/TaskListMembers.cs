using TaskGarden.Api.Domain.Enums;
using TaskGarden.Domain.Enums;

namespace TaskGarden.Api.Domain.Entities;

public class TaskListMember : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public int TasklistId { get; set; }
    public TaskList TaskList { get; set; }

    public TaskListRole Role { get; set; } = TaskListRole.Viewer;
}