using CleanMovie.Domain.EntityModels;

namespace CleanMovie.Application.Interfaces.IMovies
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMoviesFromRepo();
        Movie CreateMovieFromRepo(Movie movie);
    }
}
