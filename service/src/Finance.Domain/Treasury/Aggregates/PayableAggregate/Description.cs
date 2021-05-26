using System;
using CSharpFunctionalExtensions;

namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using Core;

    public class Description : ValueObject<Description>
    {
        //Imutabilidade
        private Description(string value)
        {
            Value = value;
        }

        public string Value { get; }

        //Factory
        public static Result<Description> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result
                    .Failure<Description>("Value is Required");
            }

            if (value.Length >= 80)
            {
                return Result
                    .Failure<Description>("Value is Too Long");
            }

            return Result
                .Success<Description>(new Description(value));
        }

        public static implicit operator string(Description description)
        {
            return description.Value;
        }
    }
}