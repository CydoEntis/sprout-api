using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Dtos.Auth;

namespace TaskGarden.Api.Services.Contracts;

public interface IAuthManager
{
    Task<AuthenticatedResponseDto> Login(LoginRequestDto loginDto);
    Task<AuthenticatedResponseDto> Register(RegisterRequestDto registerDto);
    Task<RefreshTokensResponseDto> RefreshTokens();
    Task<LogoutResponseDto> Logout();
    Task<ForgotPasswordResponseDto> ForgotPasswordAsync(ForgotPasswordRequestDto forgotPasswordRequestDto);
    Task<ResetPasswordResponseDto> ResetPasswordAsync(ResetPasswordRequestDto requestDto);
    Task<ChangePasswordResponseDto> ChangePasswordAsync(string userId, ChangePasswordRequestDto requestDto);
}