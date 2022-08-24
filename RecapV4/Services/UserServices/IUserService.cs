using RecapV4.Models.DTOs;

namespace RecapV4.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO dto);
        Task<String> LoginUser(LoginUserDTO dto);
    }
}
