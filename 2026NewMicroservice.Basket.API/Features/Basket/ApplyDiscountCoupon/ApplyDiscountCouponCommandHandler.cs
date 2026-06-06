using _2026NewMicroservice.Shared;
using MediatR;
using System.Net;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponCommandHandler(BasketService basketService) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            var basketStringData = await basketService.GetBasketAsync(cancellationToken);

            if (string.IsNullOrEmpty(basketStringData))
                return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);


            var basket = JsonSerializer.Deserialize<Data.Basket>(basketStringData);
            if (!basket!.Items.Any())
                return ServiceResult.Error("Basket Items not found", HttpStatusCode.NotFound);

            basket!.AppliedNewDiscount(request.DiscountRate, request.Coupon);

            await basketService.SetBasketAsync(basket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
