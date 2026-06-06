using _2026NewMicroservice.Basket.API.Features.Basket.Const;
using _2026NewMicroservice.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket
{
    public class BasketService(IIdentityService identityService, IDistributedCache distributedCache)
    {

        private string GetBasketCacheKey() => string.Format(CacheBasketConst.BasketCache, identityService.GetUserId);

        public async Task<string?> GetBasketAsync(CancellationToken cancellationToken)
        {
            var cacheKey = GetBasketCacheKey();
            return await distributedCache.GetStringAsync(cacheKey, cancellationToken);
        }

        public async Task SetBasketAsync(Data.Basket basket, CancellationToken cancellationToken)
        {
            var cacheKey = GetBasketCacheKey();
            await distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(basket), cancellationToken);
        }
    }
}
