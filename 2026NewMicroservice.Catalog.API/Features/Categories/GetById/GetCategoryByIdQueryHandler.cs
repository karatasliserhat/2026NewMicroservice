using System.Net;

namespace _2026NewMicroservice.Catalog.API.Features.Categories.GetById
{
    public class GetCategoryByIdQueryHandler(AppDbContext _context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id, cancellationToken);

            if (category is null)
                return ServiceResult<CategoryDto>.Error("Category not found", $"Category with is in Id:'{request.Id}' not found", HttpStatusCode.NotFound);

            var categoryMap = mapper.Map<CategoryDto>(category);

            return ServiceResult<CategoryDto>.SuccessAsOk(categoryMap);
        }
    }
}
