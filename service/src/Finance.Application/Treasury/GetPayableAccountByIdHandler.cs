namespace Finance.Application.Treasury
{
    using System.Threading.Tasks;
    using Domain.Treasury.Aggregates.PayableAggregate;

    public class GetPayableAccountByIdHandler : IGetPayableAccountByIdHandler
    {
        private readonly IPayableRepository _repository;

        public GetPayableAccountByIdHandler(IPayableRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPayableAccountByIdDto> HandleAsync(GetPayableAccountByIdQuery args)
        {
            var payable = await _repository
                .GetAsync(args.Id);

            if (payable == null)
            {
                return null;
            }

            return new GetPayableAccountByIdDto
            {
                Id = payable.Id,
                Amount = payable.Amount.Value,
                Description = payable.Description.Value,
                DocumentDate = payable.DocumentDate.Value,
                DocumentNumber = payable.DocumentNumber.Value,
                DueDate = payable.DueDate.Value,
                PaymentDate = payable.PaymentDate.Value
            };
        }
    }
}