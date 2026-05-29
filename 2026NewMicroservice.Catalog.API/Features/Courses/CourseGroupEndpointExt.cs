using _2026NewMicroservice.Catalog.API.Features.Courses.Create;

namespace _2026NewMicroservice.Catalog.API.Features.Courses
{
    public static class CourseGroupEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("/api/courses")
                .MapCreateCourseGroupumItemEnpoint()
                .WithTags("Courses");
        }
    }
}
