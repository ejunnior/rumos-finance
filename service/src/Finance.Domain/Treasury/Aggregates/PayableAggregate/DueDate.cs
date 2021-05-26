using System;
using CSharpFunctionalExtensions;

namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using Core;

    public class DueDate : ValueObject<DueDate>
    {
        private DueDate(DateTime value)
        {
            Value = value;
        }

        public DateTime Value { get; }

        public static Result<DueDate> Create(DateTime value)
        {
            return Result
                .Success<DueDate>(new DueDate(value));
        }

        public static implicit operator DateTime(DueDate dueDate)
        {
            return dueDate.Value;
        }
    }
}