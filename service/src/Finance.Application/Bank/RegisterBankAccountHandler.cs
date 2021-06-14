namespace Finance.Application.Bank
{
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;

    public class RegisterBankAccountHandler : IRegisterBankAccountHandler
    {
        private readonly IBankAccountRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public RegisterBankAccountHandler(
            IBankAccountRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(RegisterBankAccountCommand args)
        {
            var accountNumber = AccountNumber
                .Create(args.AccountNumber);

            var bankAccount = new BankAccount(accountNumber.Value);

            _repository.Add(bankAccount);

            await _unitOfWork
                .CommitAsync();
        }
    }
}