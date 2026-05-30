using _2026NewMicroservice.Catalog.API.Features.Courses.DTOs;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetAll
{
    public record GetAllCoursesQuery : IRequestServiceResult<List<CourseDto>>;
}
