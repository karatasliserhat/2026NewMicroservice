namespace _2026NewMicroservice.Discount.API.Features.Discounts.GetDiscountByCode
{
    public record GetDiscountByCodeQuery(string Code):IRequestServiceResult<GetDiscountByCodeQueryResponse>;
}
