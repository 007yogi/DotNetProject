using Microsoft.EntityFrameworkCore;
using MultipleDatabaseAPI.Models;

namespace MultipleDatabaseAPI.EFContext
{
    public class LoggingDbContext : DbContext
    {
        public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options)
        {
            
        }
        public DbSet<LogEntry> LogEntry { get; set; }
    }
}
