using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Api.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
    public string UserId { get; set; }

    [ForeignKey("UserId")] public AppUser User { get; set; }

    public ICollection<UserTasklistCategory> UserTaskListCategories { get; set; } = new List<UserTasklistCategory>();
    public ICollection<Tasklist> TaskLists { get; set; } = new List<Tasklist>();
}