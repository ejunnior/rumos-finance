namespace Finance.Domain.Creditor.Aggregates.CreditorAggregate
{
    using Core;

    public class RegisterCreditorCommand : ICommand

    {
        public RegisterCreditorCommand(
            string creditorName)
        {
            CreditorName = creditorName;
        }

        public string CreditorName { get; }
    }
}