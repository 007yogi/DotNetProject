using AuthServer.Models;
using Microsoft.EntityFrameworkCore;
using RefreshToken.Models;

namespace RefreshToken.EFContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserRegister> UserRegisters { get; set; }
        public DbSet<RefreshTokenModel> RefreshTokens { get; set; }
    }
}
