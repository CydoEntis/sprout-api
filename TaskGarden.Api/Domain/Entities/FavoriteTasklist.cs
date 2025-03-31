using System.ComponentModel.DataAnnotations.Schema;

namespace TaskGarden.Api.Domain.Entities;

public class FavoriteTasklist : BaseEntity
{
    public string UserId { get; set; }
    public int TaskListId { get; set; }

    [ForeignKey("UserId")]
    public AppUser User { get; set; }

    [ForeignKey("TaskListId")]
    public Tasklist Tasklist { get; set; }
}