using Microsoft.EntityFrameworkCore;
using OrderStore.Domain.Models;

namespace OrderStore.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
    }
}
