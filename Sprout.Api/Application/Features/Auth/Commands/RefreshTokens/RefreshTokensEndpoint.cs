using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Auth.Commands.RefreshTokens;

public static class RefreshTokensEndpoint
{
    public static void MapRefreshTokensEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/auth/refresh-tokens", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new RefreshTokensCommand());
                return Results.Ok(ApiResponse<RefreshTokensResponse>.SuccessWithData(response));
            })
            .WithName("RefreshTokens")
            .WithTags("Auth")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK);
    }
}