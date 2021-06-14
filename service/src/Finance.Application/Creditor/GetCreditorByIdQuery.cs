namespace Finance.Application.Creditor
{
    using Domain.Core;

    public class GetCreditorByIdQuery : IQuery<GetCreditorByIdDto>
    {
        public int Id { get; set; }
    }
}