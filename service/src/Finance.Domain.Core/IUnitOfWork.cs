namespace Finance.Domain.Core
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}