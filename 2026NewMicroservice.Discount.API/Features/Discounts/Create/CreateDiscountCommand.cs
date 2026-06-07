namespace _2026NewMicroservice.Discount.API.Features.Discounts.Create
{
    public record CreateDiscountCommand(Guid UserId, string Code, float Rate):IRequestServiceResult;
}
