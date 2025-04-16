using Sprout.Api.Domain.Enums;
using Sprout.Domain.Enums;

namespace Sprout.Api.Domain.Entities;

public class Invitation : BaseEntity
{
    public int TasklistId { get; set; }
    public TaskList TaskList { get; set; }

    public string InvitedUserEmail { get; set; }
    public string InviterUserId { get; set; }
    public AppUser InviterUser { get; set; }

    public string Token { get; set; } = Guid.NewGuid().ToString();
    public InvitationStatus Status { get; set; } = InvitationStatus.Pending;
    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(7);
    public TaskListRole Role { get; set; }
}