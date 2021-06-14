namespace Finance.Application.Creditor
{
    using Domain.Core;
    using Domain.Creditor.Aggregates.CreditorAggregate;

    public interface IEditCreditorHandler : ICommandHandler<EditCreditorCommand>
    {
    }
}