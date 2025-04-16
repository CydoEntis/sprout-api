using Sprout.Api.Domain.Enums;
using Sprout.Domain.Enums;

namespace Sprout.Api.Domain.Entities;

public class TaskListMember : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public int TasklistId { get; set; }
    public TaskList TaskList { get; set; }

    public TaskListRole Role { get; set; } = TaskListRole.Viewer;
}