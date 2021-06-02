namespace Finance.Infrastructure.Data.BankAccount.Repository
{
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using UnitOfWork;

    public class BankAccountRepository : Repository<BankAccount>
    {
        public BankAccountRepository(FinanceUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}