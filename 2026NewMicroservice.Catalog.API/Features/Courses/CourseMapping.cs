using _2026NewMicroservice.Catalog.API.Features.Courses.Create;

namespace _2026NewMicroservice.Catalog.API.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<Course, CreateCourseCommand>().ReverseMap();
        }
    }
}
