namespace Finance.Application.Bank
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Bank.Aggregates.BankAccountAggregate;

    public class GetBankAccountHandler : IGetBankAccountHandler
    {
        private readonly IBankAccountRepository _repository;

        public GetBankAccountHandler(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<GetBankAccountDto>> HandleAsync(GetBankAccountQuery args)
        {
            var bankAccounts = _repository
                .GetAll();

            if (bankAccounts == null)
            {
                return null;
            }

            return bankAccounts.Select(
                bankAccount => new GetBankAccountDto
                {
                    Id = bankAccount.Id,
                    AccountNumber = bankAccount.AccountNumber
                }).ToList();
        }
    }
}