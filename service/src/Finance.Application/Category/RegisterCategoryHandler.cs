namespace Finance.Application.Category
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;

    public class RegisterCategoryHandler : IRegisterCategoryHandler
    {
        private readonly ICategoryRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public RegisterCategoryHandler(
            ICategoryRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(RegisterCategoryCommand args)
        {
            var categoryName
                = CategoryName.Create(args.CategoryName);

            var category =
                new Category(categoryName.Value);

            _repository
                .Add(category);

            await _unitOfWork
                .CommitAsync();
        }
    }
}