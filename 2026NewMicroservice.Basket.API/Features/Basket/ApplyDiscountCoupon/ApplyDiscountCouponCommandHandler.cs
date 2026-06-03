using _2026NewMicroservice.Basket.API.Features.Basket.Const;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponCommandHandler(IDistributedCache distributedCache, IIdentityService identityService) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            var cachKey = string.Format(CacheBasketConst.BasketCache, identityService.GetUserId);

            var basketAsString = await distributedCache.GetStringAsync(cachKey, cancellationToken);

            if (string.IsNullOrEmpty(basketAsString))
                return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);


            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

            if (!basket!.Items.Any())
                return ServiceResult.Error("Basket Items not found", HttpStatusCode.NotFound);

            basket!.AppliedNewDiscount(request.DiscountRate, request.Coupon);

            await distributedCache.SetStringAsync(cachKey, JsonSerializer.Serialize(basket), cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
