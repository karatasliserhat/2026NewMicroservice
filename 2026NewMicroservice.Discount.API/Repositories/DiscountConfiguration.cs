using MongoDB.EntityFrameworkCore.Extensions;

namespace _2026NewMicroservice.Discount.API.Repositories
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Features.Discounts.Discount>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Features.Discounts.Discount> builder)
        {

            builder.ToCollection("discounts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasElementName("_id");
            builder.Property(x => x.UserId).HasElementName("user_id");
            builder.Property(x => x.Code).HasElementName("code").HasMaxLength(10);
            builder.Property(x => x.Rate).HasElementName("rate");
            builder.Property(x => x.Created).HasElementName("created");
            builder.Property(x => x.Updated).HasElementName("updated");
            builder.Property(x => x.Expired).HasElementName("expired");
        }
    }
}
