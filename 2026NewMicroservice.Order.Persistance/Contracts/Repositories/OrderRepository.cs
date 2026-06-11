using _2026NewMicroservice.Order.Application.Contracts.Repositories;
using _2026NewMicroservice.Order.Persistance.Context;

namespace _2026NewMicroservice.Order.Persistance.Contracts.Repositories
{
    public class OrderRepository(AppDbContext context) : GenericRepository<Guid, Domain.Entities.Order>(context), IOrderRepository
    {
    }
}
