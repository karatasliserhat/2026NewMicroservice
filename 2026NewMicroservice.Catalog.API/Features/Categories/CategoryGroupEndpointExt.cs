using _2026NewMicroservice.Catalog.API.Features.Categories.Create;
using _2026NewMicroservice.Catalog.API.Features.Categories.GetAll;
using _2026NewMicroservice.Catalog.API.Features.Categories.GetById;
using Asp.Versioning.Builder;

namespace _2026NewMicroservice.Catalog.API.Features.Categories
{
    public static class CategoryGroupEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("/api/v{version:apiVersion}/categories")
                .WithTags("Categories")
                .WithApiVersionSet(apiVersionSet)
                .MapCreateCategoryEndpoint()
                .MapGetAllCategoriesEndpoint()
                .MapGetCategoryByIdEndpoint()
                .RequireAuthorization();
        }
    }
}
