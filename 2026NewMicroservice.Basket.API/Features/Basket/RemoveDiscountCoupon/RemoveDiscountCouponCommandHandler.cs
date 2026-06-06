using _2026NewMicroservice.Shared;
using MediatR;
using System.Net;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.RemoveDiscountCoupon
{
    public class RemoveDiscountCouponCommandHandler(BasketService basketService) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            var basketStringData = await basketService.GetBasketAsync(cancellationToken);

            if (string.IsNullOrEmpty(basketStringData))
                return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketStringData);

            basket!.RemoveDiscount();

            await basketService.SetBasketAsync(basket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }
    }
}
