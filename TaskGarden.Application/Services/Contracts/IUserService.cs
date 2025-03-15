using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Services.Contracts;

public interface IUserService
{
    Task CreateUserAsync(AppUser user);

    Task<AppUser> GetUserByEmailAsync(string email);
}