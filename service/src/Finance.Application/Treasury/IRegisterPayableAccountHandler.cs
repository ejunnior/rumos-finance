namespace Finance.Application.Treasury
{
    using Domain.Core;
    using Domain.Treasury.Aggregates.PayableAggregate;

    public interface IRegisterPayableAccountHandler : ICommandHandler<RegisterPayableAccountCommand>
    {
    }
}