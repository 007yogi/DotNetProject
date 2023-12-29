using CleanMovie.Domain.EntityModels;

namespace CleanMovie.Application.Interfaces
{
    public interface ICricketRepository
    {
        string BoardName();
        string TeamName();
        string CaptainName();
        int TotalPlayers();
        Task<Cricket> CreateCricketData(Cricket cricket);
        Task<List<Cricket>> GetCricketData();
        Task<Cricket> GetCricketDataById(int id);
    }
}
