using MovieManagement.Model.Models;

namespace MovieManagement.Library.Repo
{
    public interface IDataRepository
    {
        Task<List<MovieModel>> GetMovies();
        Task<MovieModel> AddMovie(MovieModel movie);
        Task<MovieModel> GetMovieById(int id);
    }
}
