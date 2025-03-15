using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Services.Identity;

public class UserService(UserManager<AppUser> userManager) : IUserService
{
    public async Task<AppUser> GetUserByIdAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        return user ?? throw new NotFoundException("User not found.");
    }

    public async Task<AppUser> GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email)
               ?? throw new NotFoundException("User not found.");
    }

    public async Task CreateUserAsync(AppUser user)
    {
        await userManager.CreateAsync(user);
    }

    public async Task<string> GeneratePasswordResetTokenAsync(AppUser user)
    {
        return await userManager.GeneratePasswordResetTokenAsync(user);
    }


    public async Task ValidateCurrentPasswordAsync(AppUser user, string currentPassword)
    {
        var isValid = await userManager.CheckPasswordAsync(user, currentPassword);
        if (!isValid)
        {
            throw new BadRequestException(
                "Invalid Password",
                "An invalid password was entered",
                "current-password",
                "Current password does not match."
            );
        }
    }

    public async Task ChangeUserPasswordAsync(AppUser user, string currentPassword, string newPassword)
    {
        var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        if (!result.Succeeded)
        {
            throw new ResourceModificationException("Failed to change the password.");
        }
    }
}