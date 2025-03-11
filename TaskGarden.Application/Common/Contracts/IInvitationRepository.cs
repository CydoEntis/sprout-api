using TaskGarden.Application.Common.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories;

public interface IInvitationRepository : IBaseRepository<Invitation>
{
    Task<Invitation?> GetByTokenAsync(string token);
    Task<List<Invitation>> GetPendingInvitationsByEmailAsync(string email);
    Task<bool> InvitationExistsAsync(string email, int taskListId);
}