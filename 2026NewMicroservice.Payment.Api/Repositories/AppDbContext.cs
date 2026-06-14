using Microsoft.EntityFrameworkCore;

namespace _2026NewMicroservice.Payment.Api.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Payment> Payments { get; set; }
    }
}
