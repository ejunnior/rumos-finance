namespace Finance.Domain.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<TEntity>
        where TEntity : AggregateRoot
    {
        void Add(TEntity item);

        void Delete(TEntity item);

        IEnumerable<TEntity> GetAll();

        Task<TEntity> GetAsync(int id);

        void Modify(TEntity item);
    }
}