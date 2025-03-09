using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Common.Contracts;

public interface ISessionRepository : IBaseRepository<Session>
{
    Task<Session> GetByUserId(string userId);
    Task<Session> GetByRefreshToken(string refreshToken);
    Task<List<Session>> GetAllByUserId(string userId);
    Task<Session?> GetActiveSessionByUserIdAsync(string userId);
}