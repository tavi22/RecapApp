using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecapV4.Models.DTOs;
using RecapV4.Models.Entities;
using RecapV4.Repositories;

namespace RecapV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public AddressController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAddressByUserId(int id)
        {
            var address = await _repository.Address.GetByUserId(id);

            return Ok(address);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAddress([FromBody] AddressDTO dto)
        {
            _repository.Address.CreateAddress(dto);

            await _repository.SaveAsync();

            return Ok(dto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] AddressDTO dto)
        {
            _repository.Address.UpdateAddress(id, dto);

            await _repository.SaveAsync();

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            _repository.Address.DeleteAddress(id);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
