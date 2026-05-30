using _2026NewMicroservice.Catalog.API.Features.Categories;

namespace _2026NewMicroservice.Catalog.API.Features.Courses.DTOs
{
    public record CourseDto(
        Guid Id,
        string Name,
        string Description,
        decimal Price, string
        ImageUrl,
        CategoryDto Category,
        FeatureDto Feature
        );
}
