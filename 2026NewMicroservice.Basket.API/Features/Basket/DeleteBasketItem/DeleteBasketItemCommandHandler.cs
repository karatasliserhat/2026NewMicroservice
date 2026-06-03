using _2026NewMicroservice.Basket.API.Features.Basket.Const;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(IDistributedCache distributedCache, IIdentityService identityService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var userId = identityService.GetUserId;

            var cacheKey = string.Format(CacheBasketConst.BasketCache, userId);

            var basketData = await distributedCache.GetStringAsync(cacheKey, cancellationToken);

            if (string.IsNullOrEmpty(basketData))
                return ServiceResult.Error("Not Found", "Not found as basket", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketData);

            var deleteBasketItemData = basket?.Items.FirstOrDefault(x => x.Id == request.Id);

            if (deleteBasketItemData is null)
                return ServiceResult.Error("Not Found", "Not found as basketItem", HttpStatusCode.NotFound);

            basket?.Items.Remove(deleteBasketItemData!);

            var seriaizedData = JsonSerializer.Serialize(basket);

            await distributedCache.SetStringAsync(cacheKey, seriaizedData, cancellationToken);

            return ServiceResult.SuccessAsNoContent();


        }
    }
}
