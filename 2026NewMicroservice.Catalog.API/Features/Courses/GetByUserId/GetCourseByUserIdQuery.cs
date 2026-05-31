
using _2026NewMicroservice.Catalog.API.Features.Courses.DTOs;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetByUserId
{
    public record GetCourseByUserIdQuery(Guid Id) : IRequestServiceResult<List<CourseDto>>;

}
