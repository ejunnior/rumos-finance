namespace Finance.Domain.Creditor.Aggregates.CreditorAggregate
{
    using Core;

    public class DeleteCreditorCommand : ICommand
    {
        public DeleteCreditorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}