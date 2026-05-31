using _2026NewMicroservice.Catalog.API.Features.Courses.DTOs;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetById
{
    public static class GetCourseByIdEndpoint
    {
        public static RouteGroupBuilder MapGetCourseByIdEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
              (await mediator.Send(new GetCourseByIdQuery(id)))
              .ToGenericResult())
                .MapToApiVersion(1, 0)
                .WithName("GetCourseById")
                .Produces<CourseDto>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
            return group;
        }
    }
}
