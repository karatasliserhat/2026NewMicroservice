using _2026NewMicroservice.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _2026NewMicroservice.Payment.Api.Features.Payments.GetPaymentsByUserId
{
    public static class GetPaymentsByUserIdQueryEndpoint
    {
        public static RouteGroupBuilder MapGetPaymentsByUserIdQueryEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("/", async (IMediator mediator)
                => (await mediator.Send(new GetPaymentsByUserIdQuery()))
                .ToGenericResult())
                    .WithName("GetPaymentsByUseId")
                    .MapToApiVersion(1, 0)
                    .Produces(StatusCodes.Status200OK)
                    .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                    .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
                    .RequireAuthorization("ClientCredential");

            return group;
        }
    }
}
