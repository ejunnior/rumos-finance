namespace Finance.Tests.Treasury.Aggregates.PayableAggregate
{
    using Finance.Domain.Category.Aggregates.CategoryAggregate;
    using Xunit;
    using System;
    using System.Collections.Generic;
    using Finance.Domain.Bank.Aggregates.BankAccountAggregate;
    using Finance.Domain.Creditor.Aggregates.CreditorAggregate;
    using Finance.Domain.Treasury.Aggregates.PayableAggregate;

    public class PayableTests
    {
        [Fact]
        public void ShouldPayableAccountBeUpdted()
        {
            // Arrange
            var amount = Amount.Create(100);
            var dueDate = DueDate.Create(new DateTime());
            var description = Description.Create("Descricao");
            var documentDate = DocumentDate.Create(new DateTime());
            var documentNumber = DocumentNumber.Create("1109");
            var paymentDate = PaymentDate.Create(new DateTime());

            var accountNumber = AccountNumber.Create("083");
            var bankAccount = new BankAccount(accountNumber.Value);

            var categoryName = CategoryName.Create("Category Name");
            var category = new Category(categoryName.Value);

            var creditorName = CreditorName.Create("Creditor Name");
            var creditor = new Creditor(creditorName.Value);

            var payable = new Payable(
                amount: amount.Value,
                dueDate.Value,
                creditor,
                description.Value,
                documentDate.Value,
                documentNumber.Value,
                bankAccount,
                category,
                paymentDate.Value);

            var amountUpd = Amount.Create(200);
            var dueDateUpd = DueDate.Create(new DateTime());
            var descriptionUpd = Description.Create("Descricao Upd");
            var documentDateUpd = DocumentDate.Create(new DateTime());
            var documentNumberUpd = DocumentNumber.Create("1189");
            var paymentDateUpd = PaymentDate.Create(new DateTime());

            var accountNumberUpd = AccountNumber.Create("0834");
            var bankAccountUpd = new BankAccount(accountNumber.Value);

            var categoryNameUpd = CategoryName.Create("Category Name Upd");
            var categoryUpd = new Category(categoryName.Value);

            var creditorNameUpd = CreditorName.Create("Creditor Name Upd");
            var creditorUpd = new Creditor(creditorName.Value);

            // Act
            payable.Edit(
                    amount: amountUpd.Value,
                    dueDateUpd.Value,
                    creditorUpd,
                    descriptionUpd.Value,
                    documentDateUpd.Value,
                    documentNumberUpd.Value,
                    bankAccountUpd,
                    categoryUpd,
                    paymentDateUpd.Value);

            // Assert
            Assert.Equal(amountUpd.Value, payable.Amount.Value);
            Assert.Equal(amountUpd.Value, payable.Amount.Value);
            Assert.Equal(dueDateUpd.Value, payable.DueDate.Value);
            Assert.Equal(creditorUpd.CreditorName.Value, payable.Creditor.CreditorName.Value);
            Assert.Equal(descriptionUpd.Value, payable.Description.Value);
            Assert.Equal(documentDateUpd.Value, payable.DocumentDate.Value);
            Assert.Equal(documentNumberUpd.Value, payable.DocumentNumber.Value);
            Assert.Equal(bankAccountUpd.AccountNumber.Value, payable.BankAccount.AccountNumber.Value);
            Assert.Equal(paymentDateUpd.Value, payable.PaymentDate.Value);
        }

        [Fact]
        public void ShouldPayableAccountBeCreated()
        {
            // Arrange
            var amount = Amount.Create(100);
            var dueDate = DueDate.Create(new DateTime());
            var description = Description.Create("Descricao");
            var documentDate = DocumentDate.Create(new DateTime());
            var documentNumber = DocumentNumber.Create("1109");
            var paymentDate = PaymentDate.Create(new DateTime());

            var accountNumber = AccountNumber.Create("083");
            var bankAccount = new BankAccount(accountNumber.Value);

            var categoryName = CategoryName.Create("Category Name");
            var category = new Category(categoryName.Value);

            var creditorName = CreditorName.Create("Creditor Name");
            var creditor = new Creditor(creditorName.Value);

            // Act
            var sut = new Payable(
                amount: amount.Value,
                dueDate.Value,
                creditor,
                description.Value,
                documentDate.Value,
                documentNumber.Value,
                bankAccount,
                category,
                paymentDate.Value);

            // Assert
            Assert.Equal(amount.Value, sut.Amount.Value);
            Assert.Equal(amount.Value, sut.Amount.Value);
            Assert.Equal(dueDate.Value, sut.DueDate.Value);
            Assert.Equal(creditor.CreditorName.Value, sut.Creditor.CreditorName.Value);
            Assert.Equal(description.Value, sut.Description.Value);
            Assert.Equal(documentDate.Value, sut.DocumentDate.Value);
            Assert.Equal(documentNumber.Value, sut.DocumentNumber.Value);
            Assert.Equal(bankAccount.AccountNumber.Value, sut.BankAccount.AccountNumber.Value);
            Assert.Equal(paymentDate.Value, sut.PaymentDate.Value);
        }
    }
}