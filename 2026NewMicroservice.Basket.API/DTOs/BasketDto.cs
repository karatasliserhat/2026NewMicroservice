using System.Text.Json.Serialization;

namespace _2026NewMicroservice.Basket.API.DTOs
{
    public record BasketDto
    {
        

        public List<BasketItemDto> Items { get; init; } = new List<BasketItemDto>();

        public float? DiscountRate { get; set; }
        public string? Coupon { get; set; }

        [JsonIgnore]
        public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
        public decimal TotalPrice => Items.Sum(x => x.Price);
        public decimal? TotalPriceWithDiscountApplied => Items.Sum(x => x.PriceApplyDiscountRate);

        public BasketDto(List<BasketItemDto> items)
        {
            Items = items;
        }

        public BasketDto()
        {
            
        }

        
    }

}
