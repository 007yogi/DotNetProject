using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.DataEntity
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {            
        }
        public DbSet<School>schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<School>().HasData(
                new School { Id = 1, Name = "Amit", Address = "Delhi" },
                new School { Id = 2, Name = "Sumit", Address = "Delhi" },
                new School { Id = 3, Name = "Mohan", Address = "Delhi" },
                new School { Id = 4, Name = "Ram", Address = "Gurgaon" },
                new School { Id = 5, Name = "Shyam", Address = "Delhi" },
                new School { Id = 6, Name = "Monika", Address = "Delhi" }
            );
        }
    }
}
