using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Dtos.Auth;

namespace TaskGarden.Api.Services.Contracts;

public interface IAuthManager
{
    Task<AuthenticatedResponseDto> Login(LoginRequestDto loginDto);
    Task<IEnumerable<IdentityError>> Register(RegisterRequestDto registerDto);
    Task<RefreshTokensResponseDto> RefreshTokens();
    Task<LogoutResponseDto> Logout();
}