namespace _2026NewMicroservice.Order.Application.Contracts.Repositories
{
    public interface IOrderRepository:IGenericRepository<Guid, Domain.Entities.Order>
    {
        Task<List<Domain.Entities.Order>> GetOrders(Guid BuyerId);
    }
}
