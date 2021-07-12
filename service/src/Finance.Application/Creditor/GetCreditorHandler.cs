namespace Finance.Application.Creditor
{
    using System.Collections.Generic;
    using System.IO.Compression;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Finance.Domain.Core;

    public class GetCreditorHandler : IGetCreditorHandler
    {
        private readonly ICreditorRepository _repository;

        public GetCreditorHandler(ICreditorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<GetCreditorDto>> HandleAsync(GetCreditorQuery args)
        {
            var creditors = _repository
                .GetAll();

            if (creditors == null)
            {
                return null;
            }

            return creditors.Select(
                creditor => new GetCreditorDto
                {
                    Id = creditor.Id,
                    Name = creditor.CreditorName.Value
                }).ToList();
        }
    }
}