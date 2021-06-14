namespace Finance.Infrastructure.Data.BankAccount.Repository
{
    using Core;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using UnitOfWork;

    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        private readonly IFinanceUnitOfWork _unitOfWork;

        public BankAccountRepository(IFinanceUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}