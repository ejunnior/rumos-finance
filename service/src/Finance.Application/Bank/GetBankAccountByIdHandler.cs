namespace Finance.Application.Bank
{
    using System.Threading.Tasks;
    using Domain.Bank.Aggregates.BankAccountAggregate;

    public class GetBankAccountByIdHandler : IGetBankAccountByIdHandler
    {
        private readonly IBankAccountRepository _repository;

        public GetBankAccountByIdHandler(
            IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBankAccountByIdDto> HandleAsync(GetBankAccountByIdQuery args)
        {
            var bankAccount = await _repository
                .GetAsync(args.Id);

            if (bankAccount == null)
            {
                return null;
            }

            return new GetBankAccountByIdDto
            {
                Id = bankAccount.Id,
                AccountNumber = bankAccount.AccountNumber
            };
        }
    }
}