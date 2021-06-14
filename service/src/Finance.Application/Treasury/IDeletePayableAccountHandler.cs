namespace Finance.Application.Treasury
{
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Core;
    using Domain.Treasury.Aggregates.PayableAggregate;

    public interface IDeletePayableAccountHandler : ICommandHandler<DeletePayableAccountCommand>
    {
    }
}