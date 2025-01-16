namespace TaskGarden.Data.Models;

public class Session
{
    public int Id { get; set; }
    public required Guid SessionId { get; set; }
    public required string UserId { get; set; }
    public required AppUser User { get; set; }
    public required string RefreshToken { get; set; }
    public required DateTime RefreshTokenExpirationDate { get; set; }
    public bool IsVaild { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
}