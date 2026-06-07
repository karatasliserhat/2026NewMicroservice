
namespace _2026NewMicroservice.Discount.API.Features.Discounts.GetDiscountByCode
{
    public static class GetDiscountByCodeQueryEndpoint
    {
        public static RouteGroupBuilder MapGetDiscountByCodeQueryEndpoint(this RouteGroupBuilder group)
        {

            group.MapGet("/{code:length(10)}", async (string code, IMediator mediator) =>
            (await mediator.Send(new GetDiscountByCodeQuery(code)))
            .ToGenericResult())
                            .WithName("GetDiscountByCode")
                            .Produces<ServiceResult<GetDiscountByCodeQueryResponse>>(StatusCodes.Status200OK)
                            .Produces<ServiceResult<GetDiscountByCodeQueryResponse>>(StatusCodes.Status404NotFound)
                            .MapToApiVersion(1, 0);

            return group;
        }

    }
}
