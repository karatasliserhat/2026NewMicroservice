namespace _2026NewMicroservice.Basket.API.Data
{
    public class BasketItem
    {
        public BasketItem(Guid id, string name, string? imageUrl, decimal price, decimal? priceApplyDiscountRate)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            Price = price;
            PriceApplyDiscountRate = priceApplyDiscountRate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceApplyDiscountRate { get; set; }
    }
}
