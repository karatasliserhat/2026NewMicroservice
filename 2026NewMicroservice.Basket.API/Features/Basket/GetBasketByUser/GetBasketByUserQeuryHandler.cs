using _2026NewMicroservice.Basket.API.DTOs;
using _2026NewMicroservice.Basket.API.Features.Basket.Const;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.GetBasketByUser
{
    public class GetBasketByUserQeuryHandler(IDistributedCache distributedCache, IIdentityService identityService) : IRequestHandler<GetBasketByUserQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketByUserQuery request, CancellationToken cancellationToken)
        {
            var getCacheKey = string.Format(CacheBasketConst.BasketCache, identityService.GetUserId);

            var basketCache = await distributedCache.GetStringAsync(getCacheKey, cancellationToken);
            if (string.IsNullOrEmpty(basketCache))
                return ServiceResult<BasketDto>.Error("not found", "Not Found basket", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<BasketDto>(basketCache);

            return ServiceResult<BasketDto>.SuccessAsOk(basket!);
        }
    }
}
