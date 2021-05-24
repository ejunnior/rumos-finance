namespace Finance.Domain.Creditor.Aggregates.CreditorAggregate
{
    using Core;

    public class Creditor : AggregateRoot
    {
        public Creditor(CreditorName name)

        {
            CreditorName = name;
        }

        public CreditorName CreditorName { get; }
    }
}