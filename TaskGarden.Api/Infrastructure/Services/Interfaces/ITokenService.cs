using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Domain.Enums;

namespace TaskGarden.Api.Infrastructure.Services.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(AppUser user);
    RefreshToken GenerateRefreshToken();
    Task<bool> IsRefreshTokenValid(string token);

    string? ExtractTokenFromAuthorizationHeader(string authorizationHeader);
    string? ExtractUserIdFromToken(string token);

    string GenerateInviteToken(AppUser inviter, int taskListId, string taskListName,
        List<Member> taskListMembers, string inviteeEmail);
}