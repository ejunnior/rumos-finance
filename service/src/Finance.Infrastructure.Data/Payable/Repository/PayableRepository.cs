namespace Finance.Infrastructure.Data.Payable.Repository
{
    using Domain.Treasury.Aggregates.PayableAggregate;
    using UnitOfWork;

    public class PayableRepository : Repository<Payable>
    {
        public PayableRepository(FinanceUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}