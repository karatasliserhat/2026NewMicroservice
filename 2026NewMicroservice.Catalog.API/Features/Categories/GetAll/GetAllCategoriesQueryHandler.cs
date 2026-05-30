
namespace _2026NewMicroservice.Catalog.API.Features.Categories.GetAll
{
    public class GetAllCategoriesQueryHandler(AppDbContext appDbContext, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await appDbContext.Categories.ToListAsync(cancellationToken);

            var categoryDtos = mapper.Map<List<CategoryDto>>(categories);

            return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoryDtos);

        }
    }

}
