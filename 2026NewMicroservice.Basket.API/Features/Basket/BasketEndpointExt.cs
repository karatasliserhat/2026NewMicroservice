using _2026NewMicroservice.Basket.API.Features.Basket.AddBasketItem;
using _2026NewMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon;
using _2026NewMicroservice.Basket.API.Features.Basket.DeleteBasketItem;
using _2026NewMicroservice.Basket.API.Features.Basket.GetBasketByUser;
using _2026NewMicroservice.Basket.API.Features.Basket.RemoveDiscountCoupon;
using Asp.Versioning.Builder;

namespace _2026NewMicroservice.Basket.API.Features.Basket
{
    public static class BasketEndpointExt
    {
        public static void AddBasketEndpoints(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            var basketGroup = app.MapGroup("/api/v{version:apiVersion}/baskets")
                .WithTags("Baskets")
                .WithApiVersionSet(apiVersionSet)
                .MapAddBasketItemCommandEndpoint()
                .MapDeleteBasketItemCommandEndpoint()
                .MapGetBasketByUserQeuryEndpoint()
                .MapApplyDiscountCouponCommandEndpoint()
                .MapRemoveDiscountCouponCommandEnpoint()
                .RequireAuthorization();



        }
    }
}
