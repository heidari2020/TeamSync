using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamSync.Api.Features.Auth.Register;

public static class RegisterEndpoint
{
    public static void MapRegisterEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/register", async (
            [FromBody] RegisterCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return TypedResults.Ok(response);
        })
        .WithName("Register")
        .WithSummary("Registers a new user")
        .WithTags("Auth");
    }
}