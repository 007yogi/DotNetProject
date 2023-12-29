using JwtAuthDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<AuthenticationRequest> authenticationRequests { get; set; }
        public DbSet<Product>products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AuthenticationRequest>().HasData(
                new AuthenticationRequest
                {
                    Id = 1,
                    UserName = "yogesh",
                    Password = "yogesh123",
                    Email = "yogesh@gmail.com"
                },
                new AuthenticationRequest
                {
                    Id = 2,
                    UserName = "rajesh",
                    Password = "rajesh123",
                    Email = "rajesh@gmail.com"
                },
                new AuthenticationRequest
                {
                    Id = 3,
                    UserName = "sudesh",
                    Password = "sudesh123",
                    Email = "sudesh@gmail.com"
                }
              );
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Mobile",
                Description = "good Mobile product",
                Price = "2000"
            },
            new Product
            {
                Id = 2,
                Name = "Laptop",
                Description = "good Laptop product",
                Price = "20,000"
            },
            new Product
            {
                Id = 3,
                Name = "TV",
                Description = "good TV product",
                Price = "10,000"
            }
            );
        }
    }
}
