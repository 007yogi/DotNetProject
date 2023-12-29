using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Product.API.Entities;

namespace Product.API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
       public DbSet<Product.API.Entities.Product> products {  get; set; }
       public DbSet<Category> categories {  get; set; }
    }
}
