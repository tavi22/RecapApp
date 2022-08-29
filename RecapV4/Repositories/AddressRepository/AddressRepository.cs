using Microsoft.EntityFrameworkCore;
using RecapV4.Models.Data;
using RecapV4.Models.DTOs;
using RecapV4.Models.Entities;

namespace RecapV4.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(RecapContext context) : base(context) { }

        public async void CreateAddress(AddressDTO dto)
        {
            Address newAddress = new Address();

            newAddress.City = dto.City;
            newAddress.StreetName = dto.StreetName;
            newAddress.Number = dto.Number;
            newAddress.Details = dto.Details;
            newAddress.UserId = dto.UserId;

            Create(newAddress);

        }

        public async void DeleteAddress(int id)
        {
            Address address = new Address();
            address = await GetByIdAsync(id);

            Delete(address);
        }

        public async Task<List<Address>> GetByUserId(int userId)
        {
            return await _context.Addresses.Where(a => a.UserId.Equals(userId)).ToListAsync();
        }

        public async void UpdateAddress(int id, AddressDTO dto)
        {
            Address newAddress = new Address();

            newAddress.Id = id;
            newAddress.City = dto.City;
            newAddress.StreetName = dto.StreetName;
            newAddress.Number = dto.Number;
            newAddress.Details = dto.Details;
            newAddress.UserId = dto.UserId;

            Update(newAddress);

        
        }
    }
}
