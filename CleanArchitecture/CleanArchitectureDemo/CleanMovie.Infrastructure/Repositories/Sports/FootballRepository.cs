using CleanMovie.Application.Interfaces.ISports;
using CleanMovie.Domain.EntityModels;
using CleanMovie.Infrastructure.AppDbContext;
using Microsoft.IdentityModel.Tokens;

namespace CleanMovie.Infrastructure.Repositories.Sports
{
    public class FootballRepository : IFootballRepository
    {
        private readonly MovieDbContext _movieDbontext;

        public FootballRepository(MovieDbContext movieDbontext)
        {
            _movieDbontext = movieDbontext;
        }
        public string BoardName()
        {
            return "AIFF";
        }

        public string CaptainName()
        {
            return "Sunil Chhetri";
        }

        public string TeamName()
        {
            return "Indian";
        }

        public int TotalPlayers()
        {
            return 11;
        }

        public async Task<Football> InsertFootBallData(Football football)
        {
            var result = await _movieDbontext.football.AddAsync(football);
            await _movieDbontext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
