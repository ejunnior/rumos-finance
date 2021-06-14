namespace Finance.Domain.Bank.Aggregates.BankAccountAggregate
{
    using Core;

    public class EditBankAccountCommand : ICommand
    {
        public EditBankAccountCommand(
            int id,
            string accountNumber)
        {
            Id = id;
            AccountNumber = accountNumber;
        }

        public string AccountNumber { get; }

        public int Id { get; }
    }
}