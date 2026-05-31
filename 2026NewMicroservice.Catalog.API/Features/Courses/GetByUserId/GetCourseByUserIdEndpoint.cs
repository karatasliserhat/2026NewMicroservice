using _2026NewMicroservice.Catalog.API.Features.Courses.DTOs;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetByUserId
{
    public static class GetCourseByUserIdEndpoint
    {
        public static RouteGroupBuilder MapGetCourseByUserIdEndpoint(this RouteGroupBuilder grouup)
        {
            grouup.MapGet("/user/{userId:guid}", async (Guid userId, IMediator mediator) =>
            (await mediator.Send(new GetCourseByUserIdQuery(userId)))
            .ToGenericResult())
                .MapToApiVersion(1, 0)
                .WithName("GetCourseByUserId")
                .Produces<List<CourseDto>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            return grouup;
        }
    }
}
