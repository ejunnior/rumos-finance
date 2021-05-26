namespace Finance.Infrastructure.Data
{
    using Domain.Core;
    using UnitOfWork;

    public class Repository<TEntity>
        where TEntity : AggregateRoot
    {
        private readonly FinanceUnitOfWork _unitOfWork;

        public Repository(FinanceUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity item)
        {
            if (item != null)
            {
                _unitOfWork
                    .Set<TEntity>().Add(item);
            }
        }

        public TEntity Get(int id)
        {
            if (id != default)
            {
                return _unitOfWork
                    .Set<TEntity>().Find(id);
            }

            return null;
        }
    }
}