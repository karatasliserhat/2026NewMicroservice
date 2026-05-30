using _2026NewMicroservice.Catalog.API.Features.Courses.DTOs;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetAll
{
    public class GetAllCoursesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.ToListAsync(cancellationToken);

            var categories = await context.Categories.ToListAsync(cancellationToken);

            courses.ForEach(course => course.Category = categories.First(c => c.Id == course.CategoryId));

            var coursesMaoped = mapper.Map<List<CourseDto>>(courses);

            return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesMaoped);
        }
    }
}
