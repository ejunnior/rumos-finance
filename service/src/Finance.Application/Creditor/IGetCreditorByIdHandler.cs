namespace Finance.Application.Creditor
{
    using Domain.Core;

    public interface IGetCreditorByIdHandler : IQueryHandler<GetCreditorByIdQuery, GetCreditorByIdDto>
    {
    }
}