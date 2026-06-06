using _2026NewMicroservice.Basket.API.Data;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.AddBasketItem
{
    public class AddBasketItemCommandHandler(IDistributedCache distributedCache, IIdentityService identityService, BasketService basketService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {


            var basketStringData = await basketService.GetBasketAsync(cancellationToken);


            Data.Basket? currentBasketDto;

            var newBasketItem = new BasketItem(request.CourseId, request.CourseName, request.ImageUrl, request.Price, null);

            if (string.IsNullOrEmpty(basketStringData))
            {
                currentBasketDto = new Data.Basket(identityService.GetUserId, [newBasketItem], null, null);

                await basketService.SetBasketAsync(currentBasketDto, cancellationToken);

                return ServiceResult.SuccessAsNoContent();

            }
            currentBasketDto = JsonSerializer.Deserialize<Data.Basket>(basketStringData);


            var existBasketItem = currentBasketDto!.Items.FirstOrDefault(x => x.Id == request.CourseId);

            if (existBasketItem is not null)
                currentBasketDto.Items.Remove(existBasketItem);


            //sepette var olan indirimi yeni eklenen ürünede uygulamak için


            currentBasketDto.Items.Add(newBasketItem);


            currentBasketDto.AppliedAvailableDiscount();



            await basketService.SetBasketAsync(currentBasketDto, cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }

    }
}
