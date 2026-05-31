namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetAll
{
    public static class GetAllCourseEndpoint
    {
        public static RouteGroupBuilder MapGetAllCourseEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("/", async (IMediator mediator) =>
            (await mediator.Send(new GetAllCoursesQuery()))
                .ToGenericResult())
                .MapToApiVersion(1, 0)
                .WithName("GetAllCourses")
                .Produces<List<CategoryDto>>(StatusCodes.Status200OK);

            return group;
        }
    }
}
