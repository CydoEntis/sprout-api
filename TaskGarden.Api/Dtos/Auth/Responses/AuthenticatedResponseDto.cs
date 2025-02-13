namespace TaskGarden.Api.Dtos.Auth;

public class AuthenticatedResponseDto : ResponseDto
{
    public string AccessToken { get; set; }
}