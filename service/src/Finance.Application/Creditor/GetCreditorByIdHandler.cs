namespace Finance.Application.Creditor
{
    using System.Threading.Tasks;
    using Domain.Creditor.Aggregates.CreditorAggregate;

    public class GetCreditorByIdHandler : IGetCreditorByIdHandler
    {
        private readonly ICreditorRepository _repository;

        public GetCreditorByIdHandler(ICreditorRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCreditorByIdDto> HandleAsync(GetCreditorByIdQuery args)
        {
            var creditor = await _repository
                .GetAsync(args.Id);

            if (creditor == null)
            {
                return null;
            }

            return new GetCreditorByIdDto
            {
                Id = creditor.Id,
                Name = creditor.CreditorName
            };
        }
    }
}