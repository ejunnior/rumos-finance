﻿namespace Finance.Domain.Bank.Aggregates.BankAccountAggregate
{
    using Core;

    public class BankAccount : AggregateRoot
    {
        public BankAccount(AccountNumber accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public AccountNumber AccountNumber { get; }
    }
}