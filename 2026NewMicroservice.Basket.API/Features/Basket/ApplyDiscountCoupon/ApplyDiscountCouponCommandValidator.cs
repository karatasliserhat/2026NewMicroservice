using FluentValidation;

namespace _2026NewMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponCommandValidator : AbstractValidator<ApplyDiscountCouponCommand>
    {
        public ApplyDiscountCouponCommandValidator()
        {
            RuleFor(x => x.Coupon).NotEmpty().WithMessage("{PropertyName} code is required.");
            RuleFor(x => x.DiscountRate).GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
        }
    }
}
