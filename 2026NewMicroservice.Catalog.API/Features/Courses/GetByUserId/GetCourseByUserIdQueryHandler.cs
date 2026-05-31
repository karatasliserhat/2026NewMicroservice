using _2026NewMicroservice.Catalog.API.Features.Courses.DTOs;
using System.Net;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.GetByUserId
{
    public class GetCourseByUserIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByUserIdQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetCourseByUserIdQuery request, CancellationToken cancellationToken)
        {


            var courses = await context.Courses.Where(x => x.UserId == request.Id).ToListAsync();

            if (!courses.Any())
                return ServiceResult<List<CourseDto>>.Error("Not Found", $"No courses found for the specified user ID:({request.Id}).", HttpStatusCode.NotFound);


            var categories = await context.Categories.ToListAsync();

            courses.ForEach(x => x.Category = categories.FirstOrDefault(c => c.Id == x.CategoryId)!);


            var coursesDto = mapper.Map<List<CourseDto>>(courses);

            return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesDto);
        }
    }
}
