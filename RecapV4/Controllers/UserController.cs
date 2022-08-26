using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecapV4.Models.DTOs;
using RecapV4.Models.Entities;
using RecapV4.Repositories;
using RecapV4.Services.UserServices;

namespace RecapV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public UserController(IRepositoryWrapper repository, UserManager<User> userManager, IUserService userService)
        {
            _repository = repository;
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.User.GetAllUsers();

            return Ok(new { users });
        }


        [HttpGet("{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var exists = await _userManager.FindByEmailAsync(email);

            if (exists == null)
            {
                return BadRequest("User does not exist!");
            }

            var result = await _repository.User.GetUserByEmail(email);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserById(int id)
        {

            var user = await _repository.User.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound("User does not exist!");
            }

            _repository.User.Delete(user);
            await _repository.SaveAsync();
            return NoContent();

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserById(int id, [FromBody] UserDTO newUser)
        {
            var user = await _repository.User.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound("User does not exist!");
            }

            _repository.User.UpdateUserById(id, newUser, user);
            await _repository.SaveAsync();
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> CreateUserByAdmin([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User already registered!");
            }

            var result = await _userService.RegisterUserAsync(dto);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
