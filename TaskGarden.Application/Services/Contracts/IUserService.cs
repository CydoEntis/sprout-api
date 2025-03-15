using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Services.Contracts;

public interface IUserService
{
    Task<AppUser> GetUserByIdAsync(string userId);
    Task CreateUserAsync(AppUser user);
    Task<AppUser> GetUserByEmailAsync(string email);
    Task<string> GeneratePasswordResetTokenAsync(AppUser user);
    Task ValidateCurrentPasswordAsync(AppUser user, string currentPassword);
    Task ChangeUserPasswordAsync(AppUser user, string currentPassword, string newPassword);
}