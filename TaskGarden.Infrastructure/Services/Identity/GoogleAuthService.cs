using Google.Apis.Auth;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Infrastructure.Services.Identity;

public class GoogleAuthService : IGoogleAuthService
{
    public async Task<GoogleUserInfo?> ValidateGoogleIdTokenAsync(string idToken)
    {
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            return new GoogleUserInfo
            {
                Email = payload.Email,
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                GoogleId = payload.Subject
            };
        }
        catch
        {
            return null;
        }
    }
}