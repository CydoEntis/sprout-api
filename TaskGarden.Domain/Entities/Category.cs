using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public AppUser User { get; set; }
    public ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();
}