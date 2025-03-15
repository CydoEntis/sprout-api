using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Services.Contracts;

public interface IAuthSessionService
{
    Task<string> GenerateAndStoreTokensAsync(AppUser user);
}