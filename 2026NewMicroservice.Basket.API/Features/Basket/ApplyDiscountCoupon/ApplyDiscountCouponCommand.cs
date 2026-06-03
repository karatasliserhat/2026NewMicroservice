using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon
{
    public record ApplyDiscountCouponCommand(string Coupon, float DiscountRate):IRequestServiceResult;
}
