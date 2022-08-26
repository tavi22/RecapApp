using Microsoft.AspNetCore.Identity;

namespace RecapV4.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
}
