using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Application.Projections;

public class CategoryWithTaskListCount
{
    public Category Category { get; set; }
    public int TaskListCount { get; set; }
}