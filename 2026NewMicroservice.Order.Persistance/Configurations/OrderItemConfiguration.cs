using _2026NewMicroservice.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2026NewMicroservice.Order.Persistance.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x=> x.ProductId).IsRequired();
            builder.Property(x => x.ProductName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();

        }
    }
}
