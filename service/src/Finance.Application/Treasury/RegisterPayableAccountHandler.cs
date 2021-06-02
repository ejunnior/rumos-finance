namespace Finance.Application.Treasury
{
    using System.Threading.Tasks;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Domain.Treasury.Aggregates.PayableAggregate;
    using Infrastructure.Data.BankAccount.Repository;
    using Infrastructure.Data.Category.Repository;
    using Infrastructure.Data.Creditor.Repository;
    using Infrastructure.Data.Payable.Repository;
    using Infrastructure.Data.UnitOfWork;

    public class RegisterPayableAccountHandler
    {
        public async Task HandlerAsync(RegisterPayableAccountCommand command)
        {
            var unitOfWork = new FinanceUnitOfWork();

            var repository = new PayableRepository(unitOfWork);

            var amount = Amount.Create(command.Amount);
            var dueDate = DueDate.Create(command.DueDate);
            var description = Description.Create(command.Description);
            var documentDate = DocumentDate.Create(command.DocumentDate);
            var documentNumber = DocumentNumber.Create(command.DocumentNumber);
            var paymentDate = PaymentDate.Create(command.PaymentDate);

            var creditorRepository = new CreditorRepository(unitOfWork);
            var bankAccountRepository = new BankAccountRepository(unitOfWork);
            var categoryRepository = new CategoryRepository(unitOfWork);

            var creditor = await creditorRepository
                .GetAsync(command.CreditorId);

            var bankAccount = await bankAccountRepository
                .GetAsync(command.BankAccountId);

            var category = await categoryRepository
                .GetAsync(command.CategoryId);

            var payable = new Payable(
                amount: amount.Value,
                dueDate: dueDate.Value,
                creditor: creditor,
                description: description.Value,
                documentDate: documentDate.Value,
                documentNumber: documentNumber.Value,
                bankAccount: bankAccount,
                category: category,
                paymentDate: paymentDate.Value);

            repository
                .Add(payable);

            await unitOfWork
                .CommitAsync();
        }
    }
}