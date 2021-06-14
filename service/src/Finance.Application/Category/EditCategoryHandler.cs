namespace Finance.Application.Category
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;

    public class EditCategoryHandler : IEditCategoryHandler
    {
        private readonly ICategoryRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public EditCategoryHandler(
            ICategoryRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(EditCategoryCommand args)
        {
            var category = await _repository
                .GetAsync(args.Id);

            if (category != null)
            {
                var categoryName
                    = CategoryName.Create(args.CategoryName);

                category
                    .Edit(categoryName.Value);

                _repository
                    .Modify(category);

                await _unitOfWork
                    .CommitAsync();
            }
        }
    }
}