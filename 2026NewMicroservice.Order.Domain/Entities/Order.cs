using MassTransit;
using System.Text;

namespace _2026NewMicroservice.Order.Domain.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public string Code { get; set; } = null!;

        public Guid BuyerId { get; set; }
        public DateTime Created { get; set; }

        public OrderStatus Status { get; set; }

        public decimal TotalPrice { get; set; }
        public float? DiscountRate { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; } = new();

        public List<OrderItem> OrderItems { get; set; } = new();
        public Guid? PaymentId { get; set; }


        public string CreatedCode()
        {
            var random = new Random();
            var orderCode = new StringBuilder(10);

            for (int i = 0; i < orderCode.Length; i++)
            {
                orderCode.Append(random.Next(1, 10));
            }

            return orderCode.ToString();
        }

        public void AddOrderItem(int id, string productName, decimal unitPrice)
        {
            var item = new OrderItem();
            item.SetItem(id, productName, unitPrice);

            OrderItems.Add(item);
            CalculateTotalPrice();
        }
        public Order CreateUnPaidOrder(Guid buyerId, float discountRate, int AddressId)
        {
            return new Order
            {
                Id = NewId.NextSequentialGuid(),
                Code = CreatedCode(),
                Created = DateTime.Now,
                BuyerId = buyerId,
                AddressId = AddressId,
                DiscountRate = discountRate,
                Status = OrderStatus.UnPaidApproved,
                TotalPrice = 0,
                OrderItems = new()

            };
        }


        public void ApplyDiscount(float discountRate)
        {
            if (discountRate < 0 || discountRate > 0)
                throw new ArgumentException("Discount mus be grather then 0 and 100");
            DiscountRate = discountRate;

            CalculateTotalPrice();
        }


        public void SetPaidStatus(Guid paymentId)
        {
            Status = OrderStatus.Paid;
            this.PaymentId = paymentId;
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = OrderItems.Sum(x => x.UnitPrice);

            if (DiscountRate > 0)
                TotalPrice -= TotalPrice * ((decimal)DiscountRate.Value / 100);

        }



    }

    public enum OrderStatus
    {
        UnPaidApproved = 1,
        Paid = 2,
        Cancel = 3
    }
}
