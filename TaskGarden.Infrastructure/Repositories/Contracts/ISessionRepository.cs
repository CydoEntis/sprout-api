
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Contracts;


public interface ISessionRepository : IBaseRepository<Session>
{
    Task<Session> GetByUserId(string userId);
    Task<Session> GetByRefreshToken(string refreshToken);
}