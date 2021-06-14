namespace Finance.Domain.Core
{
    using System.Threading.Tasks;

    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery args);
    }
}