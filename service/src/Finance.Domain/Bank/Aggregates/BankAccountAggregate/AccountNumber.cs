using CSharpFunctionalExtensions;

namespace Finance.Domain.Bank.Aggregates.BankAccountAggregate
{
    using Core;

    public class AccountNumber : ValueObject<AccountNumber>
    {
        private AccountNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<AccountNumber> Create(string value)
        {
            return Result
                .Success<AccountNumber>(new AccountNumber(value));
        }
    }
}