namespace Finance.Application.Treasury
{
    using System;

    public class GetPayableAccountDto
    {
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime DocumentDate { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime DueDate { get; set; }

        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}