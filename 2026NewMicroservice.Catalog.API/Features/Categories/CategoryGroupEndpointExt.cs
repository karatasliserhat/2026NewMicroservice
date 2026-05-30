using _2026NewMicroservice.Catalog.API.Features.Categories.Create;
using _2026NewMicroservice.Catalog.API.Features.Categories.GetAll;
using _2026NewMicroservice.Catalog.API.Features.Categories.GetById;

namespace _2026NewMicroservice.Catalog.API.Features.Categories
{
    public static class CategoryGroupEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("/api/categories")
                .WithTags("Categories")
                .MapCreateCategoryEndpoint()
                .MapGetAllCategoriesEndpoint()
                .MapGetCategoryByIdEndpoint();
        }
    }
}
