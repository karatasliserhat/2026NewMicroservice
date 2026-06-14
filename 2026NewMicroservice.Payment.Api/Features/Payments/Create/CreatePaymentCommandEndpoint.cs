
using _2026NewMicroservice.Shared.Extensions;
using _2026NewMicroservice.Shared.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _2026NewMicroservice.Payment.Api.Features.Payments.Create
{
    public static class CreatePaymentCommandEndpoint
    {
        public static RouteGroupBuilder MapCreatePaymentCommandEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreatePaymentCommand command, IMediator mediator)
                => (await mediator.Send(command))
                .ToGenericResult())
                .WithName("CratePayment")
                .MapToApiVersion(1, 0)
                .Produces<Guid>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
                .AddEndpointFilter<ValidationFilter<CreatePaymentCommand>>();


            return group;
        }
    }
}
