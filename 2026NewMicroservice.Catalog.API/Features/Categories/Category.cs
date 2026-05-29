using _2026NewMicroservice.Catalog.API.Features.Courses;

namespace _2026NewMicroservice.Catalog.API.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;

        public List<Course>? Courses { get; set; }
    }
}
