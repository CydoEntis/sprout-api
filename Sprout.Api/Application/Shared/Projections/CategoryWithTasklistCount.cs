using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Application.Shared.Projections;

public class CategoryWithTasklistCount
{
    public Category Category { get; set; }
    public int TaskListCount { get; set; }
}