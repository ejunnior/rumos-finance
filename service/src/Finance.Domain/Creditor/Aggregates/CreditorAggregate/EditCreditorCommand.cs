namespace Finance.Domain.Creditor.Aggregates.CreditorAggregate
{
    using Core;

    public class EditCreditorCommand : ICommand
    {
        public EditCreditorCommand(
            int id,
            string creditorName)
        {
            Id = id;
            CreditorName = creditorName;
        }

        public string CreditorName { get; }

        public int Id { get; }
    }
}