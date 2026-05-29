using _2026NewMicroservice.Catalog.API.Features.Categories;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace _2026NewMicroservice.Catalog.API.Repositories
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.ToCollection("categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasElementName("name").HasMaxLength(100);
            builder.Ignore(x => x.Courses);
        }
    }
}
