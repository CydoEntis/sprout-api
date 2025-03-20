using TaskGarden.Api.Application.Features.Auth.Commands.ChangePassword;
using TaskGarden.Api.Application.Features.Auth.Commands.ForgotPassword;
using TaskGarden.Api.Application.Features.Auth.Commands.Google;
using TaskGarden.Api.Application.Features.Auth.Commands.Login;
using TaskGarden.Api.Application.Features.Auth.Commands.Logout;
using TaskGarden.Api.Application.Features.Auth.Commands.RefreshTokens;
using TaskGarden.Api.Application.Features.Auth.Commands.Register;
using TaskGarden.Api.Application.Features.Auth.Commands.ResetPassword;

namespace TaskGarden.Api.Application.Features.Auth;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapRegisterEndpoint();
        routes.MapLoginEndpoint();
        routes.MapGoogleLoginEndpoint();
        routes.MapRefreshTokensEndpoint();
        routes.MapLogoutEndpoint();
        routes.MapForgotPasswordEndpoint();
        routes.MapResetPasswordEndpoint();
        routes.MapChangePasswordEndpoint();
    }
}