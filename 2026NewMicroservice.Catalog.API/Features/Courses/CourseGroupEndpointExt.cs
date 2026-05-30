using _2026NewMicroservice.Catalog.API.Features.Courses.Create;
using _2026NewMicroservice.Catalog.API.Features.Courses.Delete;
using _2026NewMicroservice.Catalog.API.Features.Courses.GetAll;
using _2026NewMicroservice.Catalog.API.Features.Courses.GetById;
using _2026NewMicroservice.Catalog.API.Features.Courses.Update;

namespace _2026NewMicroservice.Catalog.API.Features.Courses
{
    public static class CourseGroupEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("/api/courses")
                .WithTags("Courses")
                .MapCreateCourseGroupumItemEnpoint()
                .MapGetAllCourseEndpoint()
                .MapGetCourseByIdEndpoint()
                .MapUpdateCourseCommandEndpoint()
                .MapDeleteCourseCommandEndpoint();
        }
    }
}
