namespace _2026NewMicroservice.Catalog.API.Features.Courses.Update
{
    public record UpdateCourseCommand(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string ImageUrl,
        Guid CategoryId
    ):IRequestServiceResult;
}