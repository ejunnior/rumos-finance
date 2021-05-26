using CSharpFunctionalExtensions;

namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using Core;

    public class Amount : ValueObject<Amount>
    {
        private Amount(decimal value)
        {
            Value = value;
        }

        //Obrigatorio pelo EF
        private Amount()
        {
        }

        public decimal Value { get; }

        public static Result<Amount> Create(decimal value)
        {
            if (value <= 0)
            {
                return Result
                    .Failure<Amount>("Value is Invalid!");
            }

            return Result
                .Success<Amount>(new Amount(value));
        }

        public static implicit operator decimal(Amount amount)
        {
            return amount.Value;
        }
    }
}