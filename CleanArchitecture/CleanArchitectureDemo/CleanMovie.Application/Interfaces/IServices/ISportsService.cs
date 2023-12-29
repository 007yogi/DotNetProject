using CleanMovie.Domain.EntityModels;

namespace CleanMovie.Application.Interfaces.IServices
{
    public interface ISportsService
    {
        // CRICKET TEAM
        string GetCricketBoardName();
        string GetCricketTeamName();
        string GetCricketCaptainName();
        int GetCricketTotalPlayers();

        // HOCKEY TEAM
        string GetHockeyBoardName();
        string GetHockeyTeamName();
        string GetHockeyCaptainName();
        int GetHockeyTotalPlayers();

        // FOOTBALL TEAM
        string GetFootballBoardName();
        string GetFootballTeamName();
        string GetFootballCaptainName();
        int GetFootballTotalPlayers();

        //
        Task<Cricket> CreateCricketData(Cricket cricket);
        Task<List<Cricket>> GetCricketData();
        Task<Cricket> GetCricketDataById(int Id);
        Task<Football> InsertFootballData(Football football);
        Task<Hockey> InsertHockeyData(Hockey hockey);
    }
}
