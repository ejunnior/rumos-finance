namespace Finance.Application.Bank
{
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;

    public class DeleteBankAccountHandler : IDeleteBankAccountHandler
    {
        private readonly IBankAccountRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public DeleteBankAccountHandler(
            IBankAccountRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeleteBankAccountCommand args)
        {
            var bankAccount = await
                _repository.GetAsync(args.Id);

            if (bankAccount != null)
            {
                _repository.Delete(bankAccount);

                await _unitOfWork
                    .CommitAsync();
            }
        }
    }
}