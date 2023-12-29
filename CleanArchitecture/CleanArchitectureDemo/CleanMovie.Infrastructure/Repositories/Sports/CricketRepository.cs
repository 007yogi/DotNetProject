using CleanMovie.Application.Interfaces;
using CleanMovie.Domain.EntityModels;
using CleanMovie.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Infrastructure.Repositories.Sports
{
    public class CricketRepository : ICricketRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public CricketRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public string BoardName()
        {
            return "BCCI";
        }

        public string CaptainName()
        {
            return "Rohit Sharma";
        }

        public string TeamName()
        {
            return "India";
        }

        public int TotalPlayers()
        {
            return 11;
        }
        public async Task<Cricket> CreateCricketData(Cricket cricket)
        {
            var result = await _movieDbContext.cricket.AddAsync(cricket);
            await _movieDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<List<Cricket>> GetCricketData()
        {
            var result = await _movieDbContext.cricket.ToListAsync();
            return result;
        }
        public async Task<Cricket> GetCricketDataById(int id)
        {
            var result = await _movieDbContext.cricket.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }
    }
}
