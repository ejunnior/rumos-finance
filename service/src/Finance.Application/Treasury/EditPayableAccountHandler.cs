namespace Finance.Application.Treasury
{
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Category.Aggregates.CategoryAggregate;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Domain.Treasury.Aggregates.PayableAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;

    public class EditPayableAccountHandler : IEditPayableAccountHandler
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICreditorRepository _creditorRepository;
        private readonly IPayableRepository _payableRepository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public EditPayableAccountHandler(
            IFinanceUnitOfWork unitOfWork,
            IPayableRepository payableRepository,
            ICategoryRepository categoryRepository,
            IBankAccountRepository bankAccountRepository,
            ICreditorRepository creditorRepository)
        {
            _unitOfWork = unitOfWork;
            _payableRepository = payableRepository;
            _categoryRepository = categoryRepository;
            _bankAccountRepository = bankAccountRepository;
            _creditorRepository = creditorRepository;
        }

        public async Task HandleAsync(EditPayableAccountCommand args)
        {
            var payable = await _payableRepository
                .GetAsync(args.Id);

            if (payable != null)
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

                payable.Edit(
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
                    .Modify(payable);

                await _unitOfWork
                    .CommitAsync();
            }
        }
    }
}