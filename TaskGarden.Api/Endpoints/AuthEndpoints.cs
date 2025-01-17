using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Api.Services.Contracts;

namespace TaskGarden.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/auth").WithTags("Auth");

        group.MapPost("/register", async (RegisterRequestDto registerRequestDto, IAuthManager authManager) =>
            {
                // TODO: Add in Validation Checks.

                var response = await authManager.Register(registerRequestDto);
                return Results.Ok(response);
            })
            .WithTags("Auth")
            .WithName("Register")
            .WithOpenApi()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
        
        group.MapPost("/login", async (LoginRequestDto loginRequestDto, IAuthManager authManager) =>
            {
                // TODO: Add in Validation Checks.
                var response = await authManager.Login(loginRequestDto);
                return Results.Ok(response);
            })
            .WithTags("Auth")
            .WithName("Login")
            .WithOpenApi()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
        
   
        
        
    }
}