namespace _2026NewMicroservice.Catalog.API.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name) : IRequestServiceResult<CreateCategoryResponse>;
}
