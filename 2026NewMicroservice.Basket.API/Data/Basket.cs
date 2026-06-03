using System.Text.Json.Serialization;

namespace _2026NewMicroservice.Basket.API.Data
{
    public class Basket
    {
        public Guid UserId { get; set; }
        public List<BasketItem> Items { get; set; } = new();

        public float? DiscountRate { get; set; }
        public string? Coupon { get; set; }


        public Basket()
        {

        }

        public Basket(Guid userId, List<BasketItem> items, float? discountRate, string? coupon)
        {
            UserId = userId;
            Items = items;
            DiscountRate = discountRate;
            Coupon = coupon;
        }
        [JsonIgnore]
        public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
        [JsonIgnore]
        public decimal TotalPrice => Items.Sum(x => x.Price);
        [JsonIgnore]
        public decimal? TotalPriceWithDiscountApplied => Items.Sum(x => x.PriceApplyDiscountRate);

        public void AppliedNewDiscount(float? discountRate, string? coupon)
        {
            DiscountRate = discountRate;
            Coupon = coupon;
            Items.ForEach(x => x.PriceApplyDiscountRate = x.Price * (decimal)(1 - discountRate!));
        }
        public void AppliedAvailableDiscount()
        {

            if (!IsApplyDiscount)
                return;
            Items.ForEach(x => x.PriceApplyDiscountRate = x.Price * (decimal)(1 - DiscountRate!));
        }

        public void RemoveDiscount()
        {
            Coupon = null;
            DiscountRate = null;
            Items.ForEach(x => x.PriceApplyDiscountRate = null);
        }



    }
}
