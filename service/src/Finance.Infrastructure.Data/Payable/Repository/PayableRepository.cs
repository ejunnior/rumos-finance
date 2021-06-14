namespace Finance.Infrastructure.Data.Payable.Repository
{
    using Core;
    using Domain.Treasury.Aggregates.PayableAggregate;
    using UnitOfWork;

    public class PayableRepository : Repository<Payable>, IPayableRepository
    {
        private readonly IFinanceUnitOfWork _unitOfWork;

        public PayableRepository(IFinanceUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}