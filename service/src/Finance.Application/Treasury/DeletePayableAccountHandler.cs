namespace Finance.Application.Treasury
{
    using Domain.Treasury.Aggregates.PayableAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;

    public class DeletePayableAccountHandler : IDeletePayableAccountHandler
    {
        private readonly IPayableRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public DeletePayableAccountHandler(
            IPayableRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeletePayableAccountCommand args)
        {
            var payable = await _repository
                .GetAsync(args.Id);

            if (payable != null)
            {
                _repository
                    .Delete(payable);

                await _unitOfWork
                    .CommitAsync();
            }
        }
    }
}