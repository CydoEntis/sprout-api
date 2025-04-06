using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Api.Domain.Enums;
using TaskGarden.Domain.Enums;

namespace TaskGarden.Api.Application.Shared.Projections;

public class TaskListOverview
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Member> Members { get; set; } = new List<Member>();
    public int RemainingMembers { get; set; }
    public double TaskCompletionPercentage { get; set; }
    public bool IsFavorited { get; set; }
}