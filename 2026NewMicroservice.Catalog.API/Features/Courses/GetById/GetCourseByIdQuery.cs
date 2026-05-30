using _2026NewMicroservice.Catalog.API.Features.Courses.DTOs;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetById
{
    public record GetCourseByIdQuery(Guid id) : IRequestServiceResult<CourseDto>;
}
