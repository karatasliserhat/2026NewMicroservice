namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetAll
{
    public static class GetAllCourseEndpoint
    {
        public static RouteGroupBuilder MapGetAllCourseEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("/", async (IMediator mediator) =>
            (await mediator.Send(new GetAllCoursesQuery())).ToGenericResult())
                .WithName("GetAllCourses");

            return group;
        }
    }
}
