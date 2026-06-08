using _2026NewMicroservice.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _2026NewMicroservice.File.Api.features.file.delete
{
    public static class DeleteFileCommandEndpoint
    {
        public static RouteGroupBuilder MapDeleteFileCommandEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("", async ([FromBody] DeleteFileCommand command, [FromServices] IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
                .WithName("DeleteFile")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError)
                .MapToApiVersion(1, 0);

            return group;

        }
    }
}
