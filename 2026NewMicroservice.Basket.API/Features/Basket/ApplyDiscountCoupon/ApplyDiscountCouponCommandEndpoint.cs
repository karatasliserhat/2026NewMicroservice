using _2026NewMicroservice.Shared.Extensions;
using _2026NewMicroservice.Shared.Filters;
using MediatR;

namespace _2026NewMicroservice.Basket.API.Features.Basket.ApplyDiscountCoupon
{
    public static class ApplyDiscountCouponCommandEndpoint
    {
        public static RouteGroupBuilder MapApplyDiscountCouponCommandEndpoint(this RouteGroupBuilder group)
        {
            group.MapPut("/apply-discount-coupon", async (ApplyDiscountCouponCommand command, IMediator mediator) =>
            (await mediator.Send(command))
            .ToGenericResult())
                .WithName("ApplyDiscountCoupon")
                .MapToApiVersion(1, 0)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .AddEndpointFilter<ValidationFilter<ApplyDiscountCouponCommand>>();

            return group;
        }
    }
}
