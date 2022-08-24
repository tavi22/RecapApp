using Microsoft.AspNetCore.Identity;

namespace RecapV4.Models.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
