namespace Finance.Infrastructure.Data.Creditor.Repository
{
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using UnitOfWork;

    public class CreditorRepository
        : Repository<Creditor>
    {
        public CreditorRepository(FinanceUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}