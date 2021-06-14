namespace Finance.Application.Creditor
{
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;

    public class RegisterCreditorHandler : IRegisterCreditorHandler
    {
        private readonly ICreditorRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public RegisterCreditorHandler(
            ICreditorRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(RegisterCreditorCommand args)
        {
            var creditorName
                = CreditorName.Create(args.CreditorName);

            var creditor =
                new Creditor(creditorName.Value);

            _repository
                .Add(creditor);

            await _unitOfWork
                .CommitAsync();
        }
    }
}