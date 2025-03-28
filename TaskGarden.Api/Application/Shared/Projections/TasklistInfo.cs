using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Api.Application.Shared.Projections;

public class TasklistInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CompletedTasksCount { get; set; }
    public int TotalTasksCount { get; set; }
    public bool IsCompleted { get; set; }
    public CategoryInfo CategoryInfo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public double TaskCompletionPercentage { get; set; }
    public List<Member> Members { get; set; } = new List<Member>();
    public List<TasklistItemDetail> TaskListItems { get; set; } = new List<TasklistItemDetail>();
}