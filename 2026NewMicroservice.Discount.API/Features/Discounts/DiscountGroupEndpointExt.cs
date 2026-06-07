using _2026NewMicroservice.Discount.API.Features.Discounts.Create;
using _2026NewMicroservice.Discount.API.Features.Discounts.GetDiscountByCode;
using Asp.Versioning.Builder;

namespace _2026NewMicroservice.Discount.API.Features.Discounts
{
    public static class DiscountGroupEndpointExt
    {
        public static void AddDiscountGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/discounts")
                .WithTags("Discounts")
                .WithApiVersionSet(apiVersionSet)
                .MapCreateDiscountEndpoint()
                .MapGetDiscountByCodeQueryEndpoint();
        }
    }
}
