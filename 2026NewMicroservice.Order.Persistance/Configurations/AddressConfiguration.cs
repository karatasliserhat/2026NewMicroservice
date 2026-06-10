using _2026NewMicroservice.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2026NewMicroservice.Order.Persistance.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Province).HasMaxLength(50).IsRequired();
            builder.Property(x=> x.District).HasMaxLength(50).IsRequired();
            builder.Property(x=> x.Street).HasMaxLength(50).IsRequired();
            builder.Property(x=> x.ZipCode).HasMaxLength(20).IsRequired();
            builder.Property(x=> x.Line).HasMaxLength(200).IsRequired();
        }
    }
}
