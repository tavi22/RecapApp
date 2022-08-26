using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecapV4.Models.Entities;
using System.Reflection.Emit;

namespace RecapV4.Models.Data
{
    public class RecapContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public RecapContext(DbContextOptions options) : base (options) { }

        // Db Tables Declaration
        public DbSet<SessionToken> SessionTokens { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductShoppingCart> ProductShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // user - role relationships

            builder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.UserId);

            });

            // Db Tables relationships

            // One to Many

            builder.Entity<User>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User);

            builder.Entity<User>()
                .HasMany(u => u.ShoppingCarts)
                .WithOne(sp => sp.User);

            builder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);

            builder.Entity<Address>()
                .HasMany(a => a.Orders)
                .WithOne(o => o.Address);

            // One to One

            builder.Entity<Product>()
                .HasOne(p => p.Stock)
                .WithOne(s => s.Product);

            builder.Entity<ShoppingCart>()
                .HasOne(sc => sc.Order)
                .WithOne(o => o.ShoppingCart);

            // Many to Many

            builder.Entity<ProductShoppingCart>()
                .HasKey(psc => new { psc.ProductId, psc.ShoppingCartId });

            builder.Entity<ProductShoppingCart>()
                .HasOne(psc => psc.Product)
                .WithMany(p => p.ProductShoppingCarts)
                .HasForeignKey(psc => psc.ProductId);

            builder.Entity<ProductShoppingCart>()
                .HasOne(psc => psc.ShoppingCart)
                .WithMany(sc => sc.ProductShoppingCarts)
                .HasForeignKey(psc => psc.ShoppingCartId);
        }
    }
}
