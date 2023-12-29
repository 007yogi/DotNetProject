using CleanMovie.Application.Interfaces;
using CleanMovie.Application.Interfaces.IMovies;
using CleanMovie.Application.Interfaces.IServices;
using CleanMovie.Domain.EntityModels;

namespace CleanMovie.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        // Constructor Dependency Injection.
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        // get .net service life time of 'AddScoped', 'AddScoped', 'AddTransient'.
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public List<Movie> GetAllMoviesFromService()
        {
            var movies = _movieRepository.GetAllMoviesFromRepo();
            return movies;
        }
        
        public Movie CreateMovieFromService(Movie movie)
        {
            var result = _movieRepository.CreateMovieFromRepo(movie);
            return result;
        }
    }
}
