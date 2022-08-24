using Microsoft.EntityFrameworkCore;
using RecapV4.Models.Data;
using RecapV4.Models.Entities;
using RecapV4.Repositories;

namespace RecapV4.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
       
        public UserRepository(RecapContext context) : base(context) { }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
           return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
