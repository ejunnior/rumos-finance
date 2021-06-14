namespace Finance.Application.Treasury
{
    using Domain.Treasury.Aggregates.PayableAggregate;
    using Infrastructure.Data.BankAccount.Repository;
    using Infrastructure.Data.Category.Repository;
    using Infrastructure.Data.Creditor.Repository;
    using Infrastructure.Data.Payable.Repository;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Category.Aggregates.CategoryAggregate;
    using Domain.Creditor.Aggregates.CreditorAggregate;

    public class RegisterPayableAccountHandler : IRegisterPayableAccountHandler
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICreditorRepository _creditorRepository;
        private readonly IPayableRepository _payableRepository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public RegisterPayableAccountHandler(
            IFinanceUnitOfWork unitOfWork,
            ICreditorRepository creditorRepository,
            IBankAccountRepository bankAccountRepository,
            ICategoryRepository categoryRepository,
            IPayableRepository payableRepository)
        {
            _unitOfWork = unitOfWork;
            _creditorRepository = creditorRepository;
            _bankAccountRepository = bankAccountRepository;
            _categoryRepository = categoryRepository;
            _payableRepository = payableRepository;
        }

        public async Task HandleAsync(RegisterPayableAccountCommand args)
        {
            var amount = Amount.Create(args.Amount);
            var dueDate = DueDate.Create(args.DueDate);
            var description = Description.Create(args.Description);
            var documentDate = DocumentDate.Create(args.DocumentDate);
            var documentNumber = DocumentNumber.Create(args.DocumentNumber);
            var paymentDate = PaymentDate.Create(args.PaymentDate);

            var creditor = await _creditorRepository
                .GetAsync(args.CreditorId);

            var bankAccount = await _bankAccountRepository
                .GetAsync(args.BankAccountId);

            var category = await _categoryRepository
                .GetAsync(args.CategoryId);

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

            _payableRepository
                .Add(payable);

            await _unitOfWork
                .CommitAsync();
        }
    }
}