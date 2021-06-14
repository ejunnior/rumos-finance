namespace Finance.Domain.Bank.Aggregates.BankAccountAggregate
{
    using Core;

    public class RegisterBankAccountCommand : ICommand

    {
        public RegisterBankAccountCommand(
            string accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public string AccountNumber { get; }
    }
}