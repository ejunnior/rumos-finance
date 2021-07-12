namespace Finance.Application.Creditor
{
    using System.Collections.Generic;
    using Domain.Core;

    public interface IGetCreditorHandler : IQueryHandler<GetCreditorQuery, IList<GetCreditorDto>>
    {
    }
}