using _2026NewMicroservice.Discount.API.Features.Discounts.Create;

namespace _2026NewMicroservice.Discount.API.Features.Discounts
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<CreateDiscountCommand, Discount>();
        }
    }
}
