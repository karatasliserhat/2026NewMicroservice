namespace _2026NewMicroservice.Order.Application.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);

        Task BeginTransaction(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    }
}
