using CSharpFunctionalExtensions;

namespace Finance.Domain.Category.Aggregates.CategoryAggregate
{
    using Core;

    public class CategoryName : ValueObject<CategoryName>
    {
        private CategoryName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<CategoryName> Create(string value)
        {
            return Result
                .Success<CategoryName>(new CategoryName(value));
        }

        public static implicit operator string(CategoryName categoryName)
        {
            return categoryName.Value;
        }
    }
}