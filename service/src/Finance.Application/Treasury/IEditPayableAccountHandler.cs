namespace Finance.Application.Treasury
{
    using Domain.Core;
    using Domain.Treasury.Aggregates.PayableAggregate;

    public interface IEditPayableAccountHandler : ICommandHandler<EditPayableAccountCommand>
    {
    }
}