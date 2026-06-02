using _2026NewMicroservice.Basket.API.DTOs;
using _2026NewMicroservice.Shared.Extensions;
using MediatR;

namespace _2026NewMicroservice.Basket.API.Features.Basket.GetBasketByUser
{
    public static class GetBasketByUserQeuryEndpoint
    {
        public static RouteGroupBuilder MapGetBasketByUserQeuryEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("/user", async (IMediator meditor) =>
            (await meditor.Send(new GetBasketByUserQuery()))
            .ToGenericResult())
                .WithName("GetBasketByUser")
                .Produces<BasketDto>(StatusCodes.Status200OK)
                .Produces<BasketDto>(StatusCodes.Status404NotFound);

            return group;
        }
    }
}
