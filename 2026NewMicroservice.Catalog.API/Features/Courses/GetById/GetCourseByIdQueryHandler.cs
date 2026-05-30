using _2026NewMicroservice.Catalog.API.Features.Courses.DTOs;
using System.Net;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetById
{
    public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
    {
        public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.id, cancellationToken);

            if (course is null)

                return ServiceResult<CourseDto>.Error("Course not found", $"Course Id:({request.id}) Not Found", HttpStatusCode.NotFound);

            var category = (await context.Categories.FindAsync(course.CategoryId, cancellationToken))!;

            course.Category = category;

            var courseMapping = mapper.Map<CourseDto>(course);

            return ServiceResult<CourseDto>.SuccessAsOk(courseMapping);


        }
    }
}
