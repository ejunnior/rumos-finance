﻿using System;

namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using Core;

    public class EditPayableAccountCommand : ICommand
    {
        public EditPayableAccountCommand(
            int id,
            DateTime paymentDate,
            DateTime dueDate,
            string documentNumber,
            DateTime documentDate,
            string description,
            int creditorId,
            int categoryId,
            int bankAccountId,
            decimal amount)
        {
            Id = id;
            PaymentDate = paymentDate;
            DueDate = dueDate;
            DocumentNumber = documentNumber;
            DocumentDate = documentDate;
            Description = description;
            CreditorId = creditorId;
            CategoryId = categoryId;
            BankAccountId = bankAccountId;
            Amount = amount;
        }

        public decimal Amount { get; }

        public int BankAccountId { get; }

        public int CategoryId { get; }

        public int CreditorId { get; }

        public string Description { get; }

        public DateTime DocumentDate { get; }

        public string DocumentNumber { get; }

        public DateTime DueDate { get; }

        public int Id { get; }
        public DateTime PaymentDate { get; }
    }
}