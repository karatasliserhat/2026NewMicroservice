using _2026NewMicroservice.Shared.Extensions;
using MediatR;

namespace _2026NewMicroservice.File.Api.features.file.upload
{
    public static class UploadFileCommandEndpoint
    {
        public static RouteGroupBuilder MapUploadFileCommandEndpoint(this RouteGroupBuilder group)
        {

            group.MapPost("", async (IFormFile file, IMediator mediator) =>
            (await mediator.Send(new UploadFileCommand(file))).ToGenericResult())
                .WithName("UploadFile")
                .Produces<UploadFileResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError)
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
