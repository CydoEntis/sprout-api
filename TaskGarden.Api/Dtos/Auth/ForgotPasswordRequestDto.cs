namespace TaskGarden.Api.Dtos.Auth;

public class ForgotPasswordRequestDto : ResponseDto
{
    public string Email { get; set; }
}