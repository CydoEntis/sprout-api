namespace TaskGarden.Api.Dtos.Auth;

public class ChangePasswordRequestDto
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}