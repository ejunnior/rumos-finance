namespace Finance.Domain.Creditor.Aggregates.CreditorAggregate
{
    using Core;

    public class Creditor : AggregateRoot
    {
        public Creditor(CreditorName name)

        {
            Name = name;
        }

        public CreditorName Name { get; }
    }
}