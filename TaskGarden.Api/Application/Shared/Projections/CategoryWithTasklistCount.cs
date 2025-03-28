using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Application.Projections;

public class CategoryWithTasklistCount
{
    public Category Category { get; set; }
    public int TaskListCount { get; set; }
}