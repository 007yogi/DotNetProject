using Microsoft.EntityFrameworkCore;
using MultipleDatabaseAPI.Models;

namespace MultipleDatabaseAPI.EFContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set;}
    }
}
