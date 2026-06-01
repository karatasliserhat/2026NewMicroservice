using _2026NewMicroservice.Shared.Extensions;
using _2026NewMicroservice.Shared.Filters;
using MediatR;

namespace _2026NewMicroservice.Basket.API.Features.Basket.AddBasketItem
{
    public static class AddBasketItemCommandEndpoint
    {
        public static RouteGroupBuilder MapAddBasketItemCommandEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/item", async (AddBasketItemCommand command, IMediator mediator)
                => (await mediator.Send(command))
                .ToGenericResult())
                .WithName("AddBasketItem")
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<AddBasketItemCommand>>()
                .Produces(StatusCodes.Status201Created);
            return group;
        }
    }
}
