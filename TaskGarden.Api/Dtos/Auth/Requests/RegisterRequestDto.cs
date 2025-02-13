namespace TaskGarden.Api.Dtos.Auth;

public class RegisterRequestDto : LoginRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
}