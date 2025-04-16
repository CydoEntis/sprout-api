using System.ComponentModel.DataAnnotations.Schema;

namespace Sprout.Api.Domain.Entities;

public class UserTaskListCategory : BaseEntity
{
    public string UserId { get; set; }
    public int TaskListId { get; set; }
    public int CategoryId { get; set; }

    [ForeignKey("UserId")]
    public AppUser User { get; set; }

    [ForeignKey("TaskListId")]
    public TaskList TaskList { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}