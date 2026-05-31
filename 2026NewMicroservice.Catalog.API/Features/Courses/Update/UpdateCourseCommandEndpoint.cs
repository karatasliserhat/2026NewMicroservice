namespace _2026NewMicroservice.Catalog.API.Features.Courses.Update
{
    public static class UpdateCourseCommandEndpoint
    {
        public static RouteGroupBuilder MapUpdateCourseCommandEndpoint(this RouteGroupBuilder group)
        {
            group.MapPut("/", async (UpdateCourseCommand command, IMediator mediator) =>
            (await mediator.Send(command))
            .ToGenericResult())
                .MapToApiVersion(1, 0)
                .WithName("UpdateCourse")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .AddEndpointFilter<ValidationFilter<UpdateCourseCommand>>();
            return group;
        }
    }
}
