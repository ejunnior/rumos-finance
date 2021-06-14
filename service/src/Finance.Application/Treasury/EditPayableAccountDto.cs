namespace Finance.Application.Treasury
{
    using System;

    public class EditPayableAccountDto
    {
        public decimal Amount { get; set; }

        public int BankAccountId { get; set; }

        public int CategoryId { get; set; }

        public int CreditorId { get; set; }

        public string Description { get; set; }

        public DateTime DocumentDate { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}