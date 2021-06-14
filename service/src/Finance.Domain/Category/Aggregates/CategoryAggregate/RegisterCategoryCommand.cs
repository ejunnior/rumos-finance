namespace Finance.Domain.Category.Aggregates.CategoryAggregate
{
    using Core;

    public class RegisterCategoryCommand : ICommand

    {
        public RegisterCategoryCommand(
            string categoryName)
        {
            CategoryName = categoryName;
        }

        public string CategoryName { get; }
    }
}