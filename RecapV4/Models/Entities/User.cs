using Microsoft.AspNetCore.Identity;

namespace RecapV4.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
