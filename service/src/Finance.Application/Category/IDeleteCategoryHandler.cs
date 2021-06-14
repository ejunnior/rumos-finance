namespace Finance.Application.Category
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using Domain.Core;

    public interface IDeleteCategoryHandler : ICommandHandler<DeleteCategoryCommand>
    {
    }
}