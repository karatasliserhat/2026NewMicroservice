namespace _2026NewMicroservice.Discount.API.Features.Discounts.Create
{
    public static class CreateDiscountEndpoint
    {
        public static RouteGroupBuilder MapCreateDiscountEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateDiscountCommand command, IMediator mediator) =>
            (await mediator.Send(command)).ToGenericResult())
                .WithName("CreateDiscount")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError)
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<CreateDiscountCommand>>();
            return group;
        }
    }
}
