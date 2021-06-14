namespace Finance.Domain.Core
{
    using System.Threading.Tasks;

    public interface ICommandHandler<T>
        where T : ICommand
    {
        Task HandleAsync(T args);
    }
}