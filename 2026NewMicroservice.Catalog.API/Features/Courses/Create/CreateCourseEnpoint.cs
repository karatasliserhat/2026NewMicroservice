
using Microsoft.AspNetCore.Mvc;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.Create
{
    public static class CreateCourseEnpoint
    {
        public static RouteGroupBuilder MapCreateCourseGroupumItemEnpoint(this RouteGroupBuilder group)
        {

            group.MapPost("/", async (CreateCourseCommand request, IMediator mediator) =>
             (await mediator.Send(request))
             .ToGenericResult())
                .MapToApiVersion(1, 0)
                .WithName("CreateCourse")
                .Produces<Guid>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status404NotFound)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .AddEndpointFilter<ValidationFilter<CreateCourseCommand>>();

            return group;
        }
    }
}
