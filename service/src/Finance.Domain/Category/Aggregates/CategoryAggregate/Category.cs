﻿namespace Finance.Domain.Category.Aggregates.CategoryAggregate
{
    using Core;

    public class Category : AggregateRoot
    {
        public Category(CategoryName categoryName)
        {
            CategoryName = categoryName;
        }

        public CategoryName CategoryName { get; }
    }
}