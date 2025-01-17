using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Dtos.Auth;

namespace TaskGarden.Api.Services.Contracts;

public interface IAuthManager
{
    Task<LoginResponseDto> Login(LoginRequestDto loginDto);
    Task<IEnumerable<IdentityError>> Register(RegisterRequestDto registerDto);
    Task RefreshTokens();
    Task<LogoutResponseDto> Logout();
}