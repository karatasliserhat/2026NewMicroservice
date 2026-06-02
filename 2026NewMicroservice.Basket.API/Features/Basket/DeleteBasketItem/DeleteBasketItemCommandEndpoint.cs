using _2026NewMicroservice.Shared.Extensions;
using _2026NewMicroservice.Shared.Filters;
using MediatR;

namespace _2026NewMicroservice.Basket.API.Features.Basket.DeleteBasketItem
{
    public static class DeleteBasketItemCommandEndpoint
    {
        public static RouteGroupBuilder MapDeleteBasketItemCommandEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("item/{id:guid}", async (Guid id, IMediator mediator) =>
            (await mediator.Send(new DeleteBasketItemCommand(id))).ToGenericResult())
                .WithName("DeleteBasketItem")
                .MapToApiVersion(1, 0)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);
            return group;
        }
    }
}
