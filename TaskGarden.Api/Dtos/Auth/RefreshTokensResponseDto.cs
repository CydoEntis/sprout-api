namespace TaskGarden.Api.Dtos.Auth;

public class RefreshTokensResponseDto : ResponseDto
{
    public string AccessToken { get; set; }
}