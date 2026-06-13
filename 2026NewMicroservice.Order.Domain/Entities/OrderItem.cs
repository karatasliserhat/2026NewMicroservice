namespace _2026NewMicroservice.Order.Domain.Entities
{
    public class OrderItem : BaseEntity<int>
    {

        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; } = new();


        public void SetItem(Guid productId, string productName, decimal unitPrice)
        {
            if (string.IsNullOrEmpty(productName))
                throw new ArgumentNullException(nameof(productName), "Product cannot be null");

            if (unitPrice <= 0)
                throw new ArgumentNullException(nameof(unitPrice), "Unit Price Grather Then by zero");


            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;

        }

        public void UpdataPrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentNullException(nameof(newPrice), "Unit Price Grather Then by zero");

            UnitPrice = newPrice;
        }

        public void PriceDiscountApproved(float rate)
        {
            if (rate <= 0 || rate > 100)
                throw new ArgumentException("Rate Grather Then by zero and 100");

            UnitPrice -= UnitPrice * ((decimal)rate / 100);
        }

        public bool IsSimeItem(OrderItem otherItem) 
            => this.ProductId == otherItem.ProductId;
    }


}
