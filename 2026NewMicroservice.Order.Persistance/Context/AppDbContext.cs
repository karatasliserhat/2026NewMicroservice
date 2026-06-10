using _2026NewMicroservice.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _2026NewMicroservice.Order.Persistance.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Domain.Entities.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistenceAssembly).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
