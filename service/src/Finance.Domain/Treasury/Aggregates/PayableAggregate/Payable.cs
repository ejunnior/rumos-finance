namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using Core;
    using Finance.Domain.Bank.Aggregates.BankAccountAggregate;
    using Finance.Domain.Category.Aggregates.CategoryAggregate;
    using Finance.Domain.Creditor.Aggregates.CreditorAggregate;

    public class Payable : AggregateRoot
    {
        public Payable(
            Amount amount,
            DueDate dueDate,
            Creditor creditor,
            Description description,
            DocumentDate documentDate,
            DocumentNumber documentNumber,
            BankAccount bankAccount,
            Category category,
            PaymentDate paymentDate)
        {
            Amount = amount;
            DueDate = dueDate;
            Creditor = creditor;
            Description = description;
            DocumentDate = documentDate;
            BankAccount = bankAccount;
            Category = category;
            PaymentDate = paymentDate;
            DocumentNumber = documentNumber;
        }

        private Payable()
        {
        }

        public Amount Amount { get; }

        public BankAccount BankAccount { get; }

        public Category Category { get; }

        public Creditor Creditor { get; }

        public Description Description { get; }

        public DocumentDate DocumentDate { get; }

        public DocumentNumber DocumentNumber { get; }

        public DueDate DueDate { get; }

        public PaymentDate PaymentDate { get; }
    }
}