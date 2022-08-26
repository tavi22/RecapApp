using Microsoft.EntityFrameworkCore;
using RecapV4.Models.Data;
using RecapV4.Models.DTOs;
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

        public async Task<User> GetByIdWithRoles(int id)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<User> GetUserByEmail(string email)
        {
           return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public void UpdateUserById(int id, UserDTO newUser, User oldUser)
        {
            oldUser.FirstName = newUser.FirstName;
            oldUser.LastName = newUser.LastName;
            oldUser.Email = newUser.Email;
            oldUser.PhoneNumber = newUser.PhoneNumber;
            oldUser.UserName = newUser.UserName;
            oldUser.NormalizedUserName = newUser.UserName.Normalize();
            oldUser.NormalizedEmail = newUser.Email.Normalize();
        }

        public void CreateUser(User newUser, UserDTO dto)
        {
            newUser.FirstName = dto.FirstName;
            newUser.LastName = dto.LastName;
            newUser.Email = dto.Email;
            newUser.PhoneNumber = dto.PhoneNumber;
            newUser.UserName = dto.UserName;
            newUser.NormalizedUserName = dto.UserName.Normalize();
            newUser.NormalizedEmail = dto.Email.Normalize(); ;
        }
    }
}
