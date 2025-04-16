using Sprout.Api.Domain.Entities;

namespace Sprout.Api.Application.Shared.Projections;

public class CategoryWithTasklistCount
{
    public Category Category { get; set; }
    public int TaskListCount { get; set; }
}