using _2026NewMicroservice.Basket.API.Data;
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


            Data.Basket? currentBasketDto;

            var newBasketItem = new BasketItem(request.CourseId, request.CourseName, request.ImageUrl, request.Price,null);

            if (string.IsNullOrEmpty(basketStringData))
            {
                currentBasketDto = new Data.Basket(userId, [newBasketItem], null, null);

                await CreteateCache(currentBasketDto, cacheBasket, cancellationToken);

                return ServiceResult.SuccessAsNoContent();

            }
            currentBasketDto = JsonSerializer.Deserialize<Data.Basket>(basketStringData);


            var existBasketItem = currentBasketDto!.Items.FirstOrDefault(x => x.Id == request.CourseId);

            if (existBasketItem is not null)
                currentBasketDto.Items.Remove(existBasketItem);


            //sepette var olan indirimi yeni eklenen ürünede uygulamak için


            currentBasketDto.Items.Add(newBasketItem);


            currentBasketDto.AppliedAvailableDiscount();
            


            await CreteateCache(currentBasketDto, cacheBasket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }

        public async Task CreteateCache(Data.Basket basketDto, string cacheBasket, CancellationToken cancellationToken)
        {
            await distributedCache.SetStringAsync(cacheBasket, JsonSerializer.Serialize(basketDto), token: cancellationToken);
        }
    }
}
