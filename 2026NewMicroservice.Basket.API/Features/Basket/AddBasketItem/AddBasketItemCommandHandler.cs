using _2026NewMicroservice.Basket.API.DTOs;
using _2026NewMicroservice.Basket.API.Features.Basket.Const;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.AddBasketItem
{
    public class AddBasketItemCommandHandler(IDistributedCache distributedCache, IIdentityService identityService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var userId = identityService.GetUserId;

            var cacheBasket = string.Format(CacheBasketConst.BasketCache, userId);

            var basketStringData = await distributedCache.GetStringAsync(cacheBasket);


            BasketDto? currentBasketDto;

            var newBasketItem = new BasketItemDto(request.CourseId, request.CourseName, request.ImageUrl, request.Price, null);

            if (string.IsNullOrEmpty(basketStringData))
            {
                currentBasketDto = new BasketDto(userId, [newBasketItem]);

                await CreteateCache(currentBasketDto, cacheBasket, cancellationToken);

                return ServiceResult.SuccessAsNoContent();

            }
            currentBasketDto = JsonSerializer.Deserialize<BasketDto>(basketStringData);


            var existBasketItem = currentBasketDto.Items.FirstOrDefault(x => x.Id == request.CourseId);

            if (existBasketItem is not null)
                currentBasketDto.Items.Remove(existBasketItem);


            currentBasketDto.Items.Add(newBasketItem);

            await CreteateCache(currentBasketDto, cacheBasket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }

        public async Task CreteateCache(BasketDto basketDto, string cacheBasket, CancellationToken cancellationToken)
        {
            await distributedCache.SetStringAsync(cacheBasket, JsonSerializer.Serialize(basketDto), token: cancellationToken);
        }
    }
}
