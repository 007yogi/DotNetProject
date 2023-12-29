using CleanMovie.Application.Interfaces.IMovies;
using CleanMovie.Domain.EntityModels;
using CleanMovie.Infrastructure.AppDbContext;

namespace CleanMovie.Infrastructure.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {
        public static List<Movie> movies = new List<Movie>()
        {
            new Movie{Id = 1, Name = "Test1", Cost = 10 },
            new Movie{Id = 2, Name = "Test2", Cost = 20 }
        };
        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Movie CreateMovieFromRepo(Movie movie)
        {
            _movieDbContext.movies.Add(movie);
            _movieDbContext.SaveChanges();
            return movie;
        }

        public List<Movie> GetAllMoviesFromRepo()
        {
            var result = _movieDbContext.movies.ToList();
            return result;
        }
    }
}
