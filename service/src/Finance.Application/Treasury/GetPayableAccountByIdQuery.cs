namespace Finance.Application.Treasury
{
    using Domain.Core;

    public class GetPayableAccountByIdQuery : IQuery<GetPayableAccountByIdDto>
    {
        public int Id { get; set; }
    }
}