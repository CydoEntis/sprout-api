using Sprout.Api.Application.Features.Auth.Commands.ChangePassword;
using Sprout.Api.Application.Features.Auth.Commands.ForgotPassword;
using Sprout.Api.Application.Features.Auth.Commands.Google;
using Sprout.Api.Application.Features.Auth.Commands.Login;
using Sprout.Api.Application.Features.Auth.Commands.Logout;
using Sprout.Api.Application.Features.Auth.Commands.RefreshTokens;
using Sprout.Api.Application.Features.Auth.Commands.Register;
using Sprout.Api.Application.Features.Auth.Commands.ResetPassword;

namespace Sprout.Api.Application.Features.Auth;

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