namespace TaskGarden.Data.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Tag { get; set; }

    public string UserId { get; set; }
    public AppUser User { get; set; }
}