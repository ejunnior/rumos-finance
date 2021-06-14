using Finance.Domain.Core;

namespace Finance.Infrastructure.Data.Core
{
    using Microsoft.EntityFrameworkCore;

    public interface IQueryableUnitOfWork : IUnitOfWork
    {
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : AggregateRoot;

        void SetModified<TEntity>(TEntity item) where TEntity : AggregateRoot;
    }
}