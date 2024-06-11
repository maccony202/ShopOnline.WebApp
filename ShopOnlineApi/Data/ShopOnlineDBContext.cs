using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data.Config;
using ShopOnlineApi.Entities;

namespace ShopOnlineApi.Data
{
    public class ShopOnlineDBContext : DbContext
    {
        public ShopOnlineDBContext(DbContextOptions<ShopOnlineDBContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
        }
    }
}
