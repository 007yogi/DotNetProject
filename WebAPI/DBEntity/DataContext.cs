using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DBEntity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

    }
}
