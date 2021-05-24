namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using System;
    using CSharpFunctionalExtensions;

    public class PaymentDate : Core.ValueObject<PaymentDate>
    {
        private PaymentDate(DateTime value)
        {
            Value = value;
        }

        public DateTime Value { get; }

        public static Result<PaymentDate> Create(DateTime value)
        {
            return Result
                .Success<PaymentDate>(new PaymentDate(value));
        }
    }
}