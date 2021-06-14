namespace Finance.Domain.Creditor.Aggregates.CreditorAggregate
{
    using Core;

    public class Creditor : AggregateRoot
    {
        public Creditor(CreditorName name)

        {
            CreditorName = name;
        }

        private Creditor()
        {
        }

        public CreditorName CreditorName { get; private set; }

        public void Edit(CreditorName creditorName)
        {
            CreditorName = creditorName;
        }
    }
}