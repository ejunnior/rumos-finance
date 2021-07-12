namespace Finance.Application.Treasury
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Treasury.Aggregates.PayableAggregate;

    public class GetPayableAccountHandler : IGetPayableAccountHandler
    {
        private readonly IPayableRepository _repository;

        public GetPayableAccountHandler(IPayableRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<GetPayableAccountDto>> HandleAsync(GetPayableAccountQuery args)
        {
            var payables = _repository
                .GetAll();

            return payables.Select(
                payable => new GetPayableAccountDto
                {
                    Id = payable.Id,
                    Amount = payable.Amount.Value,
                    Description = payable.Description.Value,
                    DocumentDate = payable.DocumentDate.Value,
                    DocumentNumber = payable.DocumentNumber.Value,
                    DueDate = payable.DueDate.Value,
                    PaymentDate = payable.PaymentDate.Value
                }).ToList();
        }
    }
}