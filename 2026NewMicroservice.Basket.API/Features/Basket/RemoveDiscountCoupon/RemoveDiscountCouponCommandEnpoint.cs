using _2026NewMicroservice.Shared.Extensions;
using MediatR;

namespace _2026NewMicroservice.Basket.API.Features.Basket.RemoveDiscountCoupon
{
    public static class RemoveDiscountCouponCommandEnpoint
    {
        public static RouteGroupBuilder MapRemoveDiscountCouponCommandEnpoint(this RouteGroupBuilder builder)
        {
            builder.MapDelete("remove-discount-coupon", async (IMediator mediator) =>
            (await mediator.Send(new RemoveDiscountCouponCommand()))
            .ToGenericResult())
                .WithName("RemoveDiscountCoupon")
                .MapToApiVersion(1, 0)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);
            return builder;
        }
    }
}
