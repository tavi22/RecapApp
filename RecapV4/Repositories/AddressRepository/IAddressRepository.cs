using RecapV4.Models.DTOs;
using RecapV4.Models.Entities;

namespace RecapV4.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<List<Address>> GetByUserId(int userId);
        void UpdateAddress(int id, AddressDTO dto);

        void CreateAddress(AddressDTO dto);

        void DeleteAddress(int id);
    }
}
