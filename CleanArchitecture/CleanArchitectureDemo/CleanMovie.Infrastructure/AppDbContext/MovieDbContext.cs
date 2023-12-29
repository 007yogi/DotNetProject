using CleanMovie.Domain.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Infrastructure.AppDbContext
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Cricket> cricket { get; set; }
        public DbSet<Hockey> hockey { get; set; }
        public DbSet<Football> football { get; set; }


    }
}
