namespace _2026NewMicroservice.Order.Application.Contracts.Repositories
{
    public interface IOrderRepository:IGenericRepository<Guid, Domain.Entities.Order>
    {
    }
}
