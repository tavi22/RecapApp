using RecapV4.Models.Entities;

namespace RecapV4.Models.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public UserDTO(User user)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.UserName = user.UserName;
            this.PhoneNumber = user.PhoneNumber;

        }

    }
}
