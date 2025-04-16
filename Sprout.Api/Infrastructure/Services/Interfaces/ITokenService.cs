using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Application.Shared.Projections;
using Sprout.Api.Domain.Entities;
using Sprout.Domain.Enums;

namespace Sprout.Api.Infrastructure.Services.Interfaces;

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