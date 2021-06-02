namespace Finance.Infrastructure.Data.Category.Repository
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using UnitOfWork;

    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(FinanceUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}