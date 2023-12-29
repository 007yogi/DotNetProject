using CleanMovie.Application.Interfaces;
using CleanMovie.Application.Interfaces.IServices;
using CleanMovie.Application.Interfaces.ISports;
using CleanMovie.Domain.EntityModels;

namespace CleanMovie.Application.Services
{
    public class SportsService : ISportsService
    {
        private readonly ICricketRepository _cricketRepository;
        private readonly IHockeyRepository _hockeyRepository;
        private readonly IFootballRepository _footballRepository;

        public SportsService(ICricketRepository cricketRepository, IHockeyRepository hockeyRepository, IFootballRepository footballRepository)
        {
            _cricketRepository = cricketRepository;
            _hockeyRepository = hockeyRepository;
            _footballRepository = footballRepository;

        }

        /// <summary>
        /// /////////////////// CRICKET TEAM //////////////
        /// </summary>
        /// <returns></returns>
        public string GetCricketBoardName()
        {
            return _cricketRepository.BoardName();
        }
        public string GetCricketTeamName()
        {
            return _cricketRepository.TeamName();
        }
        public string GetCricketCaptainName()
        {
            return _cricketRepository.CaptainName();
        }
        public int GetCricketTotalPlayers()
        {
            return _cricketRepository.TotalPlayers();
        }

        /// <summary>
        /// ////////////////////// HOCKEY TEAM //////////
        /// </summary>
        /// <returns></returns>
        public string GetHockeyBoardName()
        {
            return _hockeyRepository.BoardName();
        }
        public string GetHockeyTeamName()
        {
            return _hockeyRepository.TeamName();
        }
        public string GetHockeyCaptainName()
        {
            return _hockeyRepository.CaptainName();
        }
        public int GetHockeyTotalPlayers()
        {
            return _hockeyRepository.TotalPlayers();
        }

        /// <summary>
        /// FOOTBALL TEAM
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetFootballBoardName()
        {
            return _footballRepository.BoardName();
        }

        public string GetFootballTeamName()
        {
            return _footballRepository.TeamName();
        }

        public string GetFootballCaptainName()
        {
            return _footballRepository.CaptainName();
        }

        public int GetFootballTotalPlayers()
        {
            return _footballRepository.TotalPlayers();
        }

        public async Task<Cricket> CreateCricketData(Cricket cricket)
        {
            return await _cricketRepository.CreateCricketData(cricket);
        }
        public async Task<List<Cricket>> GetCricketData()
        {
            return await _cricketRepository.GetCricketData();
        }
        public async Task<Cricket> GetCricketDataById(int Id)
        {
            return await _cricketRepository.GetCricketDataById(Id);
        }

        public async Task<Football> InsertFootballData(Football football)
        {
            return await _footballRepository.InsertFootBallData(football);
        }

        public async Task<Hockey> InsertHockeyData(Hockey hockey)
        {
            return await _hockeyRepository.InsertHockeyData(hockey);
        }
    }
}
