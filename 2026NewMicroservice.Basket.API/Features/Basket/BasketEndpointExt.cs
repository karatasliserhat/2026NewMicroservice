using _2026NewMicroservice.Basket.API.Features.Basket.AddBasketItem;
using Asp.Versioning.Builder;

namespace _2026NewMicroservice.Basket.API.Features.Basket
{
    public static class BasketEndpointExt
    {
        public static void AddBasketEndpoints(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            var basketGroup = app.MapGroup("/api/v{version:apiVersion}/basket")
                .WithTags("Basket")
                .WithApiVersionSet(apiVersionSet);
            basketGroup.MapAddBasketItemCommandEndpoint();
        }
    }
}
