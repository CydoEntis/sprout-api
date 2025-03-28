using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Api.Domain.Entities;

public class UserTasklistCategory : BaseEntity
{
    public string UserId { get; set; }
    public int TaskListId { get; set; }
    public int CategoryId { get; set; }

    [ForeignKey("UserId")]
    public AppUser User { get; set; }

    [ForeignKey("TaskListId")]
    public Tasklist Tasklist { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}