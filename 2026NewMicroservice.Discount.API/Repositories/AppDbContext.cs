using MongoDB.Driver;

namespace _2026NewMicroservice.Discount.API.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Features.Discounts.Discount> Discounts { get; set; }
        public static AppDbContext Create(IMongoDatabase mongoDatabase)
        {

            var appdbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName)
                .Options;

            return new AppDbContext(appdbContextOptions);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
