using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Services.Identity;

public class UserService(UserManager<AppUser> userManager) : IUserService
{
    public async Task<AppUser> GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email)
               ?? throw new NotFoundException("User not found.");
    }
}