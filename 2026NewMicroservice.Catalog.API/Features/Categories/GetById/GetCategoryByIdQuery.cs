namespace _2026NewMicroservice.Catalog.API.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequestServiceResult<CategoryDto>;
}
