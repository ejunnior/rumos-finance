namespace Finance.Infrastructure.Data.Creditor.Repository
{
    using Core;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using UnitOfWork;

    public class CreditorRepository
        : Repository<Creditor>, ICreditorRepository
    {
        private readonly IFinanceUnitOfWork _unitOfWork;

        public CreditorRepository(IFinanceUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}