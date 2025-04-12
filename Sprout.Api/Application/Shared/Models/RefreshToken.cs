namespace TaskGarden.Api.Application.Shared.Models;


public class RefreshToken
{
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
}