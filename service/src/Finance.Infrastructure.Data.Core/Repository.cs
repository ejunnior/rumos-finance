namespace Finance.Infrastructure.Data.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Core;
    using Microsoft.EntityFrameworkCore;

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : AggregateRoot
    {
        private readonly IQueryableUnitOfWork _unitOfWork;

        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity item)
        {
            if (item != null)
            {
                GetSet()
                    .Add(item);
            }
        }

        public void Delete(TEntity item)
        {
            if (item != null)
            {
                GetSet()
                    .Remove(item);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetSet().AsEnumerable();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            if (id != default)
            {
                return await GetSet()
                    .FindAsync(id);
            }

            return null;
        }

        public void Modify(TEntity item)
        {
            if (item != null)
            {
                _unitOfWork.SetModified(item);
            }
        }

        private DbSet<TEntity> GetSet()
        {
            return _unitOfWork
                .CreateSet<TEntity>();
        }
    }
}