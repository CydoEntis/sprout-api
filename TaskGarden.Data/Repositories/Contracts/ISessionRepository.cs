using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ISessionRepository : IBaseRepository<Session>
{
    Task<Session> GetByUserId(string userId);
    Task<Session> GetByRefreshToken(string refreshToken);
}