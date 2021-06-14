namespace Finance.Application.Bank
{
    using System.Threading.Tasks;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Core;
    using Infrastructure.Data.UnitOfWork;

    public class EditBankAccountHandler : IEditBankAccountHandler
    {
        private readonly IBankAccountRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public EditBankAccountHandler(
            IBankAccountRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(EditBankAccountCommand args)
        {
            var bankAccount = await _repository
                .GetAsync(args.Id);

            if (bankAccount != null)
            {
                var accountNumber = AccountNumber
                    .Create(args.AccountNumber);

                bankAccount
                    .Edit(accountNumber.Value);

                _repository
                    .Modify(bankAccount);

                await _unitOfWork
                    .CommitAsync();
            }
        }
    }
}