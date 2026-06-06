using _2026NewMicroservice.Shared;
using MediatR;
using System.Net;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(BasketService basketService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketStringData = await basketService.GetBasketAsync(cancellationToken);

            if (string.IsNullOrEmpty(basketStringData))
                return ServiceResult.Error("Not Found", "Not found as basket", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketStringData);

            var deleteBasketItemData = basket?.Items.FirstOrDefault(x => x.Id == request.Id);

            if (deleteBasketItemData is null)
                return ServiceResult.Error("Not Found", "Not found as basketItem", HttpStatusCode.NotFound);

            basket?.Items.Remove(deleteBasketItemData!);

            await basketService.SetBasketAsync(basket!, cancellationToken);

            return ServiceResult.SuccessAsNoContent();


        }
    }
}
