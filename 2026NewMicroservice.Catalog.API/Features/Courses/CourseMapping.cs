using _2026NewMicroservice.Catalog.API.Features.Courses.Create;
using _2026NewMicroservice.Catalog.API.Features.Courses.DTOs;
using _2026NewMicroservice.Catalog.API.Features.Courses.Update;

namespace _2026NewMicroservice.Catalog.API.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
