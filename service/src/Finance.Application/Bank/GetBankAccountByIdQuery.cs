namespace Finance.Application.Bank
{
    using Domain.Core;

    public class GetBankAccountByIdQuery : IQuery<GetBankAccountByIdDto>
    {
        public int Id { get; set; }
    }
}