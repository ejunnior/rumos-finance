namespace Finance.Application.Treasury
{
    using Domain.Core;

    public interface IGetPayableAccountByIdHandler : IQueryHandler<GetPayableAccountByIdQuery, GetPayableAccountByIdDto>
    {
    }
}