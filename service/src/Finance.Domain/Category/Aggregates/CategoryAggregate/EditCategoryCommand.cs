namespace Finance.Domain.Category.Aggregates.CategoryAggregate
{
    using Core;

    public class EditCategoryCommand : ICommand
    {
        public EditCategoryCommand(
            int id,
            string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }

        public string CategoryName { get; }

        public int Id { get; }
    }
}