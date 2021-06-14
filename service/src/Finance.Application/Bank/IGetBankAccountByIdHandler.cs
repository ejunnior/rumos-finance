namespace Finance.Application.Bank
{
    using Domain.Core;

    public interface IGetBankAccountByIdHandler : IQueryHandler<GetBankAccountByIdQuery, GetBankAccountByIdDto>
    {
    }
}