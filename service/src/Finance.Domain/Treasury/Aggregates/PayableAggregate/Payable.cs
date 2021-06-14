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

        public Amount Amount { get; private set; }

        public BankAccount BankAccount { get; private set; }

        public Category Category { get; private set; }

        public Creditor Creditor { get; private set; }

        public Description Description { get; private set; }

        public DocumentDate DocumentDate { get; private set; }

        public DocumentNumber DocumentNumber { get; private set; }

        public DueDate DueDate { get; private set; }

        public PaymentDate PaymentDate { get; private set; }

        public void Edit(
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
    }
}