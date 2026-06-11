using _2026NewMicroservice.Order.Application.Features.Order.Create;
using _2026NewMicroservice.Shared.Extensions;
using _2026NewMicroservice.Shared.Filters;
using MediatR;

namespace _2026NewMicroservice.Order.Api.Endpoints.Order
{
    public static class CreateOrderEndpoint
    {
        public static RouteGroupBuilder MapCreateOrderEnpoint(this RouteGroupBuilder group)
        {

            group.MapPost("/", async (CreateOrderCommand command, IMediator mediator)
                => (await mediator.Send(command)).ToGenericResult())
                .WithName("CreateOrder")
                .MapToApiVersion(1, 0)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .AddEndpointFilter<ValidationFilter<CreateCommandValidator>>();
            return group;

        }
    }
}
