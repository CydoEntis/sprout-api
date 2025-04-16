using System.ComponentModel.DataAnnotations.Schema;

namespace Sprout.Api.Domain.Entities;

public class FavoriteTaskList : BaseEntity
{
    public string UserId { get; set; }
    public int TaskListId { get; set; }

    [ForeignKey("UserId")]
    public AppUser User { get; set; }

    [ForeignKey("TaskListId")]
    public TaskList TaskList { get; set; }
}