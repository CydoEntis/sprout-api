using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Services.Contracts;

public interface IUserService
{
    Task<AppUser> GetUserByEmailAsync(string email);
}