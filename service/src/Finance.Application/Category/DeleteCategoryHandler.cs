namespace Finance.Application.Category
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using Infrastructure.Data.UnitOfWork;
    using System.Threading.Tasks;

    public class DeleteCategoryHandler : IDeleteCategoryHandler
    {
        private readonly ICategoryRepository _repository;
        private readonly IFinanceUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(
            ICategoryRepository repository,
            IFinanceUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeleteCategoryCommand args)
        {
            var category = await
                _repository.GetAsync(args.Id);

            if (category != null)
            {
                _repository.Delete(category);

                await _unitOfWork
                    .CommitAsync();
            }
        }
    }
}