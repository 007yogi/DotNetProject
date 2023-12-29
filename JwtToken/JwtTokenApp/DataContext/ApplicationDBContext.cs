using JwtTokenApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtTokenApp.DataContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<UserModel> userModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().HasData(
               new UserModel
               {
                   Id = 1,
                   loginId = "yogesh",
                   password = "yogesh123"
               },
               new UserModel
               {
                   Id = 2,
                   loginId = "rajesh",
                   password = "rajesh123"
               },
               new UserModel
               {
                   Id = 3,
                   loginId = "sudesh",
                   password = "sudesh123"
               }
             );
        }
    }
}
