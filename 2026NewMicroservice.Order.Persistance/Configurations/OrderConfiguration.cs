using Microsoft.EntityFrameworkCore;

namespace _2026NewMicroservice.Order.Persistance.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Domain.Entities.Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.BuyerId).IsRequired();
            builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DiscountRate);
            builder.Property(x => x.PaymentId);
            builder.Property(x => x.AddressId).IsRequired();
            builder.Property(x => x.Created).IsRequired();

            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressId);
        }
    }
}
