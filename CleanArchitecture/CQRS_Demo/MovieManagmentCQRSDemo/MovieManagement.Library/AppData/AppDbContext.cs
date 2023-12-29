using Microsoft.EntityFrameworkCore;
using MovieManagement.Model.Models;

namespace MovieManagement.Library.AppData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<MovieModel> movieModels { get; set; }
    }
}
