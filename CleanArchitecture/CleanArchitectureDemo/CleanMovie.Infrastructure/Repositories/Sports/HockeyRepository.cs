using CleanMovie.Application.Interfaces.ISports;
using CleanMovie.Domain.EntityModels;
using CleanMovie.Infrastructure.AppDbContext;

namespace CleanMovie.Infrastructure.Repositories.Sports
{
    public class HockeyRepository : IHockeyRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public HockeyRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public string BoardName()
        {
            return "hockeyindia";
        }

        public string CaptainName()
        {
            return "Manpreet Singh";
        }

        public string TeamName()
        {
            return "India";
        }

        public int TotalPlayers()
        {
            return 11;
        }
        public async Task<Hockey> InsertHockeyData(Hockey hockey)
        {
            var result = await _movieDbContext.hockey.AddAsync(hockey);
            await _movieDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
