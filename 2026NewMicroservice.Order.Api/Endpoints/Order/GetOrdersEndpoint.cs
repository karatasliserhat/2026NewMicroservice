using _2026NewMicroservice.Order.Application.Features.Order.GetOrders;
using _2026NewMicroservice.Shared.Extensions;
using MediatR;

namespace _2026NewMicroservice.Order.Api.Endpoints.Order
{
    public static class GetOrdersEndpoint
    {
        public static RouteGroupBuilder MapGetOrdersEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("/", async (IMediator mediator)
                => (await mediator.Send(new GetOrdersQuery()))
                .ToGenericResult())
                .WithName("GetOrders")
                .MapToApiVersion(1,0)
                .Produces<List<GetOrderResponse>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            return group;
        }
    }
}
