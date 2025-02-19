// using TaskGarden.Api.Constants;
// using TaskGarden.Api.Dtos.Auth;
// using TaskGarden.Api.Services.Contracts;
// using TaskGarden.Infrastructure.Models;
//
// namespace TaskGarden.Api.Endpoints;
//
// public static class AuthEndpoints
// {
//     public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
//     {
//         var group = routes.MapGroup("/api/auth").WithTags("Auth");
//
//         group.MapPost("/register", async (RegisterRequestDto registerRequestDto, IAuthManager authManager) =>
//             {
//                 var response = await authManager.Register(registerRequestDto);
//                 return Results.Ok(ApiResponse<AuthenticatedResponseDto>.SuccessResponse(response));
//             })
//             .WithName("Register")
//             .Produces(StatusCodes.Status400BadRequest)
//             .Produces(StatusCodes.Status200OK);
//
//         group.MapPost("/login", async (LoginRequestDto loginRequestDto, IAuthManager authManager) =>
//             {
//                 var response = await authManager.Login(loginRequestDto);
//                 return Results.Ok(ApiResponse<AuthenticatedResponseDto>.SuccessResponse(response));
//             })
//             .WithName("Login")
//             .Produces(StatusCodes.Status400BadRequest)
//             .Produces(StatusCodes.Status200OK);
//
//         group.MapPost("/refresh-tokens", async (ICookieManager cookieManager, IAuthManager authManager) =>
//             {
//                 var response = await authManager.RefreshTokens();
//                 return Results.Ok(ApiResponse<RefreshTokensResponseDto>.SuccessResponse(response));
//             })
//             .WithName("RefreshTokens")
//             .Produces(StatusCodes.Status400BadRequest)
//             .Produces(StatusCodes.Status404NotFound)
//             .Produces(StatusCodes.Status200OK);
//
//         group.MapPost("/logout",
//                 async (HttpContext httpContext, ICookieManager cookieManager, IAuthManager authManager) =>
//                 {
//                     var cookies = httpContext.Request.Cookies;
//
//                     if (cookies.ContainsKey(CookieConsts.RefreshToken))
//                     {
//                         var authToken = cookies[CookieConsts.RefreshToken];
//
//                         // Print the token to the console
//                         Console.WriteLine($"Received auth token: {authToken}");
//                         var response = await authManager.Logout();
//                         return Results.Ok(ApiResponse<LogoutResponseDto>.SuccessResponse(response));
//                     }
//
//                     return Results.Ok(ApiResponse<LogoutResponseDto>.SuccessResponse("Test"));
//                 })
//             .WithName("Logout")
//             .Produces(StatusCodes.Status400BadRequest)
//             .Produces(StatusCodes.Status404NotFound)
//             .Produces(StatusCodes.Status200OK);
//
//         group.MapPost("/forgot-password", async (ForgotPasswordRequestDto requestDto, IAuthManager authManager) =>
//             {
//                 var response = await authManager.ForgotPasswordAsync(requestDto);
//                 return Results.Ok(ApiResponse<ForgotPasswordResponseDto>.SuccessResponse(response));
//             })
//             .WithName("ForgotPassword")
//             .Produces(StatusCodes.Status400BadRequest)
//             .Produces(StatusCodes.Status404NotFound)
//             .Produces(StatusCodes.Status200OK);
//
//         group.MapPost("/reset-password", async (ResetPasswordRequestDto requestDto, IAuthManager authManager) =>
//             {
//                 var response = await authManager.ResetPasswordAsync(requestDto);
//                 return Results.Ok(ApiResponse<ResetPasswordResponseDto>.SuccessResponse(response));
//             })
//             .WithName("ResetPassword")
//             .Produces(StatusCodes.Status400BadRequest)
//             .Produces(StatusCodes.Status404NotFound)
//             .Produces(StatusCodes.Status200OK);
//
//         group.MapPost("/change-password",
//                 async (string userId, ChangePasswordRequestDto requestDto, IAuthManager authManager) =>
//                 {
//                     var response = await authManager.ChangePasswordAsync(userId, requestDto);
//                     return Results.Ok(ApiResponse<ChangePasswordResponseDto>.SuccessResponse(response));
//                 })
//             .WithName("ChangePassword")
//             .Produces(StatusCodes.Status400BadRequest)
//             .Produces(StatusCodes.Status404NotFound)
//             .Produces(StatusCodes.Status200OK);
//     }
// }