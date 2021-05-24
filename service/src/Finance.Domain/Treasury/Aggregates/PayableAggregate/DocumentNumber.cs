namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using System;
    using CSharpFunctionalExtensions;

    public class DocumentNumber : Core.ValueObject<DocumentNumber>
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
    }
}