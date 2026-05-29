
using System.Net;

namespace _2026NewMicroservice.Catalog.API.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext _context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryData = await _context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (categoryData)
            {
                return ServiceResult<CreateCategoryResponse>.Error("Category already exists.", $"Category already exists: {request.Name}", HttpStatusCode.BadRequest);
            }

            var category = new Category
            {
                Id = NewId.NextSequentialGuid(),
                Name = request.Name
            };

            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new(category.Id), category.Id.ToString());
        }
    }
}
