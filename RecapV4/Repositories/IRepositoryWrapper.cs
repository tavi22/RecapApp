using RecapV4.Repositories;

namespace RecapV4.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        Task SaveAsync();

    }
}
