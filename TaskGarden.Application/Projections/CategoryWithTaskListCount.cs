namespace TaskGarden.Infrastructure.Projections;

public class CategoryWithTaskListCount
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string CategoryTag { get; set; }
    public int TaskListCount { get; set; }
    

}