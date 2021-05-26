using CSharpFunctionalExtensions;

namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using System;
    using Core;

    public class PaymentDate : ValueObject<PaymentDate>
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

        public static implicit operator DateTime(PaymentDate paymentDate)
        {
            return paymentDate.Value;
        }
    }
}