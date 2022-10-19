namespace Finance.Application.Bank
{
    using System.Collections.Generic;
    using Domain.Core;

    public interface IGetBankAccountHandler : IQueryHandler<GetBankAccountQuery, IList<GetBankAccountDto>>
    {
    }
}