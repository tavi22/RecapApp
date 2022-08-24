using RecapV4.Models.Entities;
using RecapV4.Repositories;

namespace RecapV4.Repositories
{ 
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);
    }
}
