using Microsoft.EntityFrameworkCore;
using UploadImage.Model;

namespace UploadImage.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Product>ProductImage{ get; set; }
    }
}
