using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MovieManagement.Library.AppData;
using MovieManagement.Model.Models;

namespace MovieManagement.Library.Repo
{
    public class DataRepository : IDataRepository
    {
        private readonly AppDbContext _appDbContext;
        public DataRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        /*public static List<MovieModel> _movies = new List<MovieModel>() {
            new MovieModel{Id = 1, Name = "Test Movie1", Cost = 100},
            new MovieModel{Id = 2, Name = "Test Movie2", Cost = 200}
        };*/

        public async Task<MovieModel> AddMovie(MovieModel movie)
        {
            var result = await _appDbContext.movieModels.AddAsync(movie);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<MovieModel>> GetMovies()
        {
            var result = await _appDbContext.movieModels.ToListAsync();
            return result;
        }
        public async Task<MovieModel> GetMovieById(int id)
        {
            var result = await _appDbContext.movieModels.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }
    }
}
