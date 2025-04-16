using Sprout.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using Sprout.Api.Domain.Enums;
using Sprout.Domain.Enums;

namespace Sprout.Api.Application.Shared.Projections;

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