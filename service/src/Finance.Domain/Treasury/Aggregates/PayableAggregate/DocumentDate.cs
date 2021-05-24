using CSharpFunctionalExtensions;

namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using System;

    public class DocumentDate : Core.ValueObject<DocumentDate>
    {
        private DocumentDate(DateTime value)
        {
            Value = value;
        }

        public DateTime Value { get; }

        public static Result<DocumentDate> Create(DateTime value)
        {
            return Result
                .Success<DocumentDate>(new DocumentDate(value));
        }
    }
}