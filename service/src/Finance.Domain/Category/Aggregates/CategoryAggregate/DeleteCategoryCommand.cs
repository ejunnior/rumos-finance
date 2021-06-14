namespace Finance.Domain.Category.Aggregates.CategoryAggregate
{
    using Core;

    public class DeleteCategoryCommand : ICommand
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}