using System;
using CSharpFunctionalExtensions;

namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using Core;

    public class DocumentDate : ValueObject<DocumentDate>
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

        public static implicit operator DateTime(DocumentDate documentDate)
        {
            return documentDate.Value;
        }
    }
}