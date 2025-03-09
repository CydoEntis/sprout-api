// using Google.Apis.Auth;
// using Google.Apis.Auth.OAuth2;
// using Google.Apis.Util.Store;
// using Microsoft.Extensions.Configuration;
// using TaskGarden.Application.Services.Contracts;
// using System.Threading;
// using System.Threading.Tasks;
// using Google.Apis.Auth.OAuth2.Flows;
// using TaskGarden.Application.Features.Shared.Models;
//
// namespace TaskGarden.Infrastructure.Services.Identity
// {
//     public class GoogleAuthService : IGoogleAuthService
//     {
//         private readonly IConfiguration _configuration;
//
//         public GoogleAuthService(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }
//
//         public async Task<GoogleUserInfo?> GetUserInfoFromCodeAsync(string authorizationCode)
//         {
//             try
//             {
//                 // Retrieve client credentials from config
//                 var clientId = _configuration["Authentication:Google:ClientId"];
//                 var clientSecret = _configuration["Authentication:Google:ClientSecret"];
//                 var redirectUri = "https://localhost:5173/login";
//
//                 // Create an OAuth2 flow
//                 var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
//                 {
//                     ClientSecrets = new ClientSecrets
//                     {
//                         ClientId = clientId,
//                         ClientSecret = clientSecret
//                     },
//                     Scopes = new[] { "openid", "profile", "email" }
//                 });
//
//                 // Exchange the authorization code for tokens
//                 var tokenResponse = await flow.ExchangeCodeForTokenAsync(
//                     "user",
//                     authorizationCode,
//                     redirectUri,
//                     CancellationToken.None);
//
//                 // Validate the token and get user info
//                 var payload = await GoogleJsonWebSignature.ValidateAsync(tokenResponse.IdToken);
//
//                 if (payload == null)
//                 {
//                     return null;
//                 }
//
//                 return new GoogleUserInfo
//                 {
//                     Email = payload.Email,
//                     FirstName = payload.GivenName,
//                     LastName = payload.FamilyName,
//                     GoogleId = payload.Subject
//                 };
//             }
//             catch
//             {
//                 return null;
//             }
//         }
//     }
// }

using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Microsoft.Extensions.Configuration;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Infrastructure.Services.Identity;

public class GoogleAuthService : IGoogleAuthService
{
    private readonly IConfiguration _configuration;

    public GoogleAuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<GoogleUserInfo?> GetUserInfoFromCodeAsync(string authorizationCode)
    {
        try
        {
            var clientId = _configuration["Authentication:Google:ClientId"];
            var clientSecret = _configuration["Authentication:Google:ClientSecret"];

            var redirectUri = "postmessage";

            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                }
            });

            var tokenResponse = await flow.ExchangeCodeForTokenAsync(
                "user", 
                authorizationCode, 
                redirectUri, 
                CancellationToken.None);

            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenResponse.IdToken);

            return new GoogleUserInfo
            {
                Email = payload.Email,
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                GoogleId = payload.Subject
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error exchanging token: {ex.Message}");
            return null;
        }
    }
}