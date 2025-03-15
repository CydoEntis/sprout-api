using Microsoft.AspNetCore.Identity;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Services.Contracts;

public interface IUserService
{
    Task<AppUser> GetUserByIdAsync(string userId);
    Task CreateUserAsync(AppUser user);
    Task CreateUserAsync(AppUser user, string password);

    Task<AppUser> GetUserByEmailAsync(string email);
    Task<string> GeneratePasswordResetTokenAsync(AppUser user);
    Task ValidateCurrentPasswordAsync(AppUser user, string currentPassword);
    Task ChangeUserPasswordAsync(AppUser user, string currentPassword, string newPassword);
    Task<bool> VerifyPasswordResetTokenAsync(AppUser user, string token);
    Task<PasswordVerificationResult> VerifyPasswordAsync(AppUser user, string password);
    Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword);
}