using CleanMovie.Domain.EntityModels;

namespace CleanMovie.Application.Interfaces.ISports
{
    public interface IHockeyRepository
    {
        string BoardName();
        string TeamName();
        string CaptainName();
        int TotalPlayers();
        Task<Hockey> InsertHockeyData(Hockey hockey);
    }
}
