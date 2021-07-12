namespace Finance.Application.Treasury
{
    using System.Collections.Generic;
    using Domain.Core;

    public interface IGetPayableAccountHandler : IQueryHandler<GetPayableAccountQuery, IList<GetPayableAccountDto>>
    {
    }
}