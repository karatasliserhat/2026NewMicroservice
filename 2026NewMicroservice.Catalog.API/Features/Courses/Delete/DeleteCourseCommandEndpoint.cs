namespace _2026NewMicroservice.Catalog.API.Features.Courses.Delete
{
    public static class DeleteCourseCommandEndpoint
    {
        public static RouteGroupBuilder MapDeleteCourseCommandEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) =>
            (await mediator.Send(new DeleteCourseCommand(id)))
            .ToGenericResult())
            .MapToApiVersion(1, 0)
            .WithName("DeleteCourse")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
            return group;
        }
    }
}
