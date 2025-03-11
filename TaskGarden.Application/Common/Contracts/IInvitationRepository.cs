using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories;

public interface IInvitationRepository
{
    Task<Invitation?> GetByTokenAsync(string token);
    Task<List<Invitation>> GetPendingInvitationsByEmailAsync(string email);
    Task<bool> InvitationExistsAsync(string email, int taskListId);
}