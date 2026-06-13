using _2026NewMicroservice.Order.Application.Contracts.Repositories;
using _2026NewMicroservice.Order.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace _2026NewMicroservice.Order.Persistance.Contracts.Repositories
{
    public class OrderRepository(AppDbContext context) : GenericRepository<Guid, Domain.Entities.Order>(context), IOrderRepository
    {
        public async Task<List<Domain.Entities.Order>> GetOrders(Guid BuyerId)
        {
            return await context.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == BuyerId).ToListAsync();
        }
    }
}
