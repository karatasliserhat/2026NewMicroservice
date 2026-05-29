using _2026NewMicroservice.Catalog.API.Features.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace _2026NewMicroservice.Catalog.API.Repositories
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToCollection("courses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasElementName("name").HasMaxLength(100);
            builder.Property(c => c.Description).HasElementName("description").HasMaxLength(1000);
            builder.Property(c => c.Price).HasElementName("price");
            builder.Property(c => c.ImageUrl).HasElementName("imageUrl").HasMaxLength(200);
            builder.Property(c => c.Created).HasElementName("created");
            builder.Property(c => c.CategoryId).HasElementName("categoryId");
            builder.Ignore(x => x.Category);

            builder.OwnsOne(x => x.Feature, feauter =>
            {
                feauter.Property(x => x.Duration).HasElementName("duration");
                feauter.Property(x => x.Rating).HasElementName("rating");
                feauter.Property(x => x.EducationFullName).HasElementName("educationFullName");
            });
        }
    }
}
