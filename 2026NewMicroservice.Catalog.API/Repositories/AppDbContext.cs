using _2026NewMicroservice.Catalog.API.Features.Categories;
using _2026NewMicroservice.Catalog.API.Features.Courses;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace _2026NewMicroservice.Catalog.API.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;



        public static AppDbContext Create(IMongoDatabase mongoDatabase)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName);

            return new AppDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
