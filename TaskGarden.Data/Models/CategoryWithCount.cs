namespace TaskGarden.Data.Models;

public class CategoryWithCount
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string CategoryTag { get; set; }
    public int TaskListCount { get; set; }
    

}