using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Api.Infrastructure.Services.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(AppUser user);
    RefreshToken GenerateRefreshToken();
    Task<bool> IsRefreshTokenValid(string token);

    string? ExtractTokenFromAuthorizationHeader(string authorizationHeader);
    string? ExtractUserIdFromToken(string token);

    string GenerateInviteToken(AppUser inviter, int taskListId, string taskListName,
        string taskListCategoryName, List<Member> taskListMembers);
}