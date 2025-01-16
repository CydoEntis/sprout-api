namespace TaskGarden.Data.Models;

public class Session : BaseEntity
{
    public required string SessionId { get; set; }
    public required string UserId { get; set; }
    public AppUser User { get; set; }
    public required string RefreshToken { get; set; }
    public required DateTime RefreshTokenExpirationDate { get; set; }
    public bool IsVaild { get; set; } = true;
}