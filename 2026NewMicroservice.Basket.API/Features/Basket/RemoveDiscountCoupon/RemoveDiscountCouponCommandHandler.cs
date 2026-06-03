using _2026NewMicroservice.Basket.API.Features.Basket.Const;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.RemoveDiscountCoupon
{
    public class RemoveDiscountCouponCommandHandler(IDistributedCache distributedCache, IIdentityService identityService) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            var getCacheKey = string.Format(CacheBasketConst.BasketCache, identityService.GetUserId);

            var basketAsString = await distributedCache.GetStringAsync(getCacheKey, cancellationToken);

            if (string.IsNullOrEmpty(basketAsString))
                return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

            basket!.RemoveDiscount();

            var basketAsJson = JsonSerializer.Serialize(basket);

            await distributedCache.SetStringAsync(getCacheKey, basketAsJson, cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }
    }
}
