using _2026NewMicroservice.Catalog.API.Features.Categories;
using _2026NewMicroservice.Catalog.API.Features.Courses;

namespace _2026NewMicroservice.Catalog.API.Repositories
{
    public static class SeedData
    {
        public static async Task AddSeedData(this WebApplication app)
        {

            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

            if (!dbContext.Categories.Any())
            {
                await dbContext.Categories.AddRangeAsync(
                   new Category { Id = NewId.NextSequentialGuid(), Name = "Development" },
                   new Category { Id = NewId.NextSequentialGuid(), Name = "Business" },
                   new Category { Id = NewId.NextSequentialGuid(), Name = "Design" },
                   new Category { Id = NewId.NextSequentialGuid(), Name = "Marketing" },
                   new Category { Id = NewId.NextSequentialGuid(), Name = "IT & Software" }
               );
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Courses.Any())
            {
                var category = (await dbContext.Categories.FirstOrDefaultAsync())!;

                var roundUserId = NewId.NextSequentialGuid();

                await dbContext.Courses.AddRangeAsync(
                    new Course
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "C# Programming Masterclass",
                        Description = "Master C# programming with this comprehensive course.",
                        Price = 49.99m,
                        CategoryId = category.Id,
                        ImageUrl = "https://example.com/images/csharp-course.jpg",
                        UserId = roundUserId,
                        Created = DateTime.UtcNow,
                        Feature = new() { Duration = 10, Rating = 5, EducationFullName = "Ali Haydar KARATAŞLI" }
                    },
                    new Course
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Business Analysis Fundamentals",
                        Description = "Learn the fundamentals of business analysis and how to apply them in real-world scenarios.",
                        Price = 39.99m,
                        CategoryId = category.Id,
                        ImageUrl = "https://example.com/images/business-analysis-course.jpg",
                        UserId = roundUserId,
                        Created = DateTime.UtcNow,
                        Feature = new() { Duration = 10, Rating = 5, EducationFullName = "Ali Haydar KARATAŞLI" }
                    },
                    new Course
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Graphic Design Mastery",
                        Description = "Discover the principles of graphic design and create stunning visuals.",
                        Price = 29.99m,
                        CategoryId = category.Id,
                        ImageUrl = "https://example.com/images/graphic-design-course.jpg",
                        UserId = roundUserId,
                        Created = DateTime.UtcNow,
                        Feature = new() { Duration = 10, Rating = 5, EducationFullName = "Ali Haydar KARATAŞLI" }
                    }
                );

                await dbContext.SaveChangesAsync();
            }

        }
    }
}
