namespace Finance.Application.Creditor
{
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;

    public class DeleteCreditorHandler : IDeleteCreditorHandler
    {
        private readonly ICreditorRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public DeleteCreditorHandler(
            ICreditorRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeleteCreditorCommand args)
        {
            var creditor = await
                _repository.GetAsync(args.Id);

            if (creditor != null)
            {
                _repository
                    .Delete(creditor);

                await _unitOfWork
                    .CommitAsync();
            }
        }
    }
}