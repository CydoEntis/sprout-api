using TaskGarden.Domain.Enums;

namespace TaskGarden.Api.Domain.Entities;

public class Invitation : BaseEntity
{
    public int TaskListId { get; set; }
    public Tasklist Tasklist { get; set; }

    public string InvitedUserEmail { get; set; }
    public string InviterUserId { get; set; }
    public AppUser InviterUser { get; set; }

    public string Token { get; set; } = Guid.NewGuid().ToString();
    public InvitationStatus Status { get; set; } = InvitationStatus.Pending;
    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(7);
}