using System;
using CSharpFunctionalExtensions;

namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using Core;

    public class DocumentNumber : ValueObject<DocumentNumber>
    {
        private DocumentNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<DocumentNumber> Create(string value)
        {
            return Result
                .Success<DocumentNumber>(new DocumentNumber(value));
        }

        public static implicit operator string(DocumentNumber documentNumber)
        {
            return documentNumber.Value;
        }
    }
}