
namespace _2026NewMicroservice.Catalog.API.Features.Categories.GetAll
{
    public class GetAllCategoryQueryHandler(AppDbContext appDbContext, IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await appDbContext.Categories.ToListAsync(cancellationToken);

            var categoryDtos = mapper.Map<List<CategoryDto>>(categories);

            return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoryDtos);

        }
    }

}
