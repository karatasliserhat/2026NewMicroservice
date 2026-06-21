using _2026NewMicroservice.Catalog.API.Features.Courses.Create;
using _2026NewMicroservice.Catalog.API.Features.Courses.Delete;
using _2026NewMicroservice.Catalog.API.Features.Courses.GetAll;
using _2026NewMicroservice.Catalog.API.Features.Courses.GetById;
using _2026NewMicroservice.Catalog.API.Features.Courses.GetByUserId;
using _2026NewMicroservice.Catalog.API.Features.Courses.Update;
using Asp.Versioning.Builder;

namespace _2026NewMicroservice.Catalog.API.Features.Courses
{
    public static class CourseGroupEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("/api/v{version:apiVersion}/courses")
                .WithTags("Courses")
                .WithApiVersionSet(apiVersionSet)
                .MapCreateCourseGroupumItemEnpoint()
                .MapGetAllCourseEndpoint()
                .MapGetCourseByIdEndpoint()
                .MapUpdateCourseCommandEndpoint()
                .MapDeleteCourseCommandEndpoint()
                .MapGetCourseByUserIdEndpoint()
                .RequireAuthorization();
        }
    }
}
