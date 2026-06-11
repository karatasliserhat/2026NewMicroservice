using _2026NewMicroservice.Order.Application.Contracts.Repositories;
using _2026NewMicroservice.Order.Domain.Entities;
using _2026NewMicroservice.Order.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _2026NewMicroservice.Order.Persistance.Contracts.Repositories
{
    public class GenericRepository<TId, TEntity>(AppDbContext context) : IGenericRepository<TId, TEntity> where TId : struct where TEntity : BaseEntity<TId>
    {
        protected AppDbContext context = context;

        private readonly DbSet<TEntity> dbset = context.Set<TEntity>();


        public void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        public async Task<bool> AnyAsync(TId id)
        {
            return await dbset.AnyAsync(x => x.Id.Equals(id));
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbset.AnyAsync(predicate);
        }

        public void Delete(TEntity entity)
        {
            dbset.Remove(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbset.ToListAsync();
        }

        public Task<List<TEntity>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return dbset.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(TId id)
        {
            return (await dbset.FindAsync(id))!;
        }

        public void Update(TEntity entity)
        {
            dbset.Update(entity);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset.Where(predicate);
        }
    }
}
