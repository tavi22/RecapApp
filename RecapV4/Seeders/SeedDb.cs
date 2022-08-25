using Microsoft.AspNetCore.Identity;
using RecapV4.Models.Constants;
using RecapV4.Models.Data;
using RecapV4.Models.Entities;

namespace RecapV4.Seeders
{
    public class SeedDb
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly RecapContext _context;

        public SeedDb(RoleManager<Role> roleManager, RecapContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public async Task SeedRoles()
        {
            if (_context.Roles.Any())
            {
                return;
            }

            string[] roleNames =
            {
                UserRoleType.Admin,
                UserRoleType.User
            };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    roleResult = await _roleManager.CreateAsync(new Role
                    {
                        Name = roleName
                    });
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
