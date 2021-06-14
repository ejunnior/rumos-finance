using System;

namespace Finance.Domain.Treasury.Aggregates.PayableAggregate
{
    using Core;

    public class DeletePayableAccountCommand : ICommand
    {
        public DeletePayableAccountCommand(
            int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}