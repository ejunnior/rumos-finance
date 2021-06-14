namespace Finance.Application.Creditor
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;
    using Domain.Creditor.Aggregates.CreditorAggregate;

    public class EditCreditorHandler : IEditCreditorHandler
    {
        private readonly ICreditorRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public EditCreditorHandler(
            ICreditorRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(EditCreditorCommand args)
        {
            var creditor = await _repository
                .GetAsync(args.Id);

            if (creditor != null)
            {
                var creditorName
                    = CreditorName.Create(args.CreditorName);

                creditor
                    .Edit(creditorName.Value);

                _repository
                    .Modify(creditor);

                await _unitOfWork
                    .CommitAsync();
            }
        }
    }
}