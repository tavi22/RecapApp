using Microsoft.AspNetCore.Identity;
using RecapV4.Models.Constants;
using RecapV4.Models.DTOs;
using RecapV4.Models.Entities;
using RecapV4.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace RecapV4.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryWrapper _repository;

        public UserService(UserManager<User> userManager, IRepositoryWrapper repository)
        {
            _userManager = userManager;
            _repository = repository;
        }
        public async Task<bool> RegisterUserAsync(RegisterUserDTO dto)
        {

            var newUser = new User();
            newUser.Email = dto.Email;
            newUser.FirstName = dto.FirstName;
            newUser.LastName = dto.FirstName;

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoleType.Admin);

                return true;
            }

            return false;
        }


        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
                user = await _repository.User.GetByIdWithRoles(user.Id);

                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

                // Generate JSON Token
                var newJti = Guid.NewGuid().ToString();

                var tokenHandler = new JwtSecurityTokenHandler();



            }

            return "";
        }
    }
}
