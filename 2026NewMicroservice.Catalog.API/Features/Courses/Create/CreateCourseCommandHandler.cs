using System.Net;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.Create
{
    public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.AnyAsync(c => c.Id == request.CategoryId, cancellationToken);
            if (!hasCategory)
                return ServiceResult<Guid>.Error("Category not found", $"Category Id({request.CategoryId}) not found", HttpStatusCode.NotFound);

            var hasCourse = await context.Courses.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (hasCourse)
                return ServiceResult<Guid>.Error("Course already exists", $"Course with name({request.Name}) already exists", HttpStatusCode.BadRequest);

            var course = mapper.Map<Course>(request);
            course.Created = DateTime.Now;
            course.Id = NewId.NextSequentialGuid();

            var feature = new Feature
            {
                Duration = 10, // otomotik hesaplanacak,
                Rating = 0,
                EducationFullName = "Ali Haydar Karataşlı"//Tokendan alınacak
            };

            course.Feature = feature;

            await context.Courses.AddAsync(course, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<Guid>.SuccessAsCreated(course.Id, $"/api/courses/{course.Id}");



        }
    }
}
