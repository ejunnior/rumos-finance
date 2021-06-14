namespace Finance.Domain.Bank.Aggregates.BankAccountAggregate
{
    using System;
    using Core;

    public class DeleteBankAccountCommand : ICommand
    {
        public DeleteBankAccountCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}