namespace Finance.Application.Bank
{
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Core;

    public interface IRegisterBankAccountHandler : ICommandHandler<RegisterBankAccountCommand>
    {
    }
}