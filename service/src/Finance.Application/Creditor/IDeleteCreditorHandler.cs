namespace Finance.Application.Creditor
{
    using Domain.Core;
    using Domain.Creditor.Aggregates.CreditorAggregate;

    public interface IDeleteCreditorHandler : ICommandHandler<DeleteCreditorCommand>
    {
    }
}