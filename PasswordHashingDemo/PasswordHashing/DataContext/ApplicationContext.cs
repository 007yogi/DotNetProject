using Microsoft.EntityFrameworkCore;
using PasswordHashing.Models;

namespace PasswordHashing.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<User>users { get; set; }
    }
}
