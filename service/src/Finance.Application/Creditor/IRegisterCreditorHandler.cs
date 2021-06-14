namespace Finance.Application.Creditor
{
    using Domain.Core;
    using Finance.Domain.Creditor.Aggregates.CreditorAggregate;

    public interface IRegisterCreditorHandler : ICommandHandler<RegisterCreditorCommand>
    {
    }
}