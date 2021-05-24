using CSharpFunctionalExtensions;

namespace Finance.Domain.Creditor.Aggregates.CreditorAggregate
{
    using Core;

    public class CreditorName : ValueObject<CreditorName>
    {
        private CreditorName(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        // Factory
        public static Result<CreditorName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result
                    .Failure<CreditorName>("Value is Required");
            }

            if (value.Length >= 80)
            {
                return Result
                    .Failure<CreditorName>("Value is Too Long");
            }

            return new CreditorName(value);
        }
    }
}