using _2026NewMicroservice.Order.Application.Contracts.UnitOfWork;
using _2026NewMicroservice.Order.Persistance.Context;

namespace _2026NewMicroservice.Order.Persistance.Contracts.UnitOfWork
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task BeginTransaction(CancellationToken cancellationToken = default)
        {
            await context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await context.Database.CommitTransactionAsync(cancellationToken);
        }
    }
}
