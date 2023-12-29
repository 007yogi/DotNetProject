using CleanMovie.Application.CQRS.Command;
using CleanMovie.Application.CQRS.Queries;
using CleanMovie.Application.Interfaces.IServices;
using CleanMovie.Domain.EntityModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly ISportsService _sportsService;
        private readonly IMediator _mediator;
        public SportController(ISportsService sportsService)
        {
            _sportsService = sportsService;
        }

        /// <summary>
        /// CRICKET TEAM
        /// </summary>
        /// <returns></returns>

        [HttpGet("CricketBoardName")]
        public ActionResult CricketBoardName()
        {           
            var result = _sportsService.GetCricketBoardName();
            return Ok("Cricket Borad Name Is = " + result);
        }

        [HttpGet("CricketTeamName")]
        public IActionResult CricketTeamName()
        {
            var result = _sportsService.GetCricketTeamName();
            return Ok("Cricket Team Name = " + result);
        }

        [HttpGet("CricketCaptainName")]
        public IActionResult CricketCaptainName()
        {
            var result = _sportsService.GetCricketCaptainName();
            return Ok("Cricket Captain Name : " + result);
        }

        [HttpGet("CricketTotalPlayers")]
        public IActionResult CricketTotalPlayers()
        {
            var result = _sportsService.GetCricketTotalPlayers();
            return Ok("Total Players in Cricket Team = " + result);
        }

        /// <summary>
        /// HOCKEY TEAM
        /// </summary>
        /// <returns></returns>
        [HttpGet("HockeyBoardName")]
        public IActionResult HockeyBoardName()
        {
            var result = _sportsService.GetHockeyBoardName();
            return Ok("Hockey Board Name is = " + result);
        }

        [HttpGet("HockeyTeamName")]
        public IActionResult HockeyTeamName()
        {
            var result = _sportsService.GetHockeyTeamName();
            return Ok("Hockey Team Name is = " + result);
        }

        [HttpGet("HockeyCaptainName")]
        public IActionResult HockeyCaptainName()
        {
            var result = _sportsService.GetHockeyCaptainName();
            return Ok("Hockey Captain Name is = " + result);
        }

        [HttpGet("HockeyTotalPlayers")]
        public IActionResult HockeyTotalPlayers()
        {
            var result = _sportsService.GetHockeyTotalPlayers();
            return Ok("Hockey Total Players is = " + result);
        }

        /// <summary>
        /// FOOTBALL TEAM
        /// </summary>
        /// <returns></returns>
        [HttpGet("FootballBoardName")]
        public IActionResult FootballBoardName()
        {
            var result = _sportsService.GetFootballBoardName();
            return Ok("Football Board Name is = " + result);
        }

        [HttpGet("FootballTeamName")]
        public IActionResult FoorballTeamName()
        {
            var result = _sportsService.GetFootballTeamName();
            return Ok("Football Team Name is = " + result);
        }

        [HttpGet("FootballCaptainName")]
        public IActionResult FootballCaptainName()
        {
            var result = _sportsService.GetFootballCaptainName();
            return Ok("Football Captain Name is = " + result);
        }

        [HttpGet("FootballTotalPlayers")]
        public IActionResult FootballTotalPlayers()
        {
            var result = _sportsService.GetFootballTotalPlayers();
            return Ok("Football Total Players is = " + result);
        }

        [HttpPost("CreateCricketData")]
        public async Task<IActionResult> CreateCricketData(Cricket cricket)
        {
            //var command = new CreateCricketCommand(cricket);
            var result = await _sportsService.CreateCricketData(cricket);
            return Ok(result);
        }

        [HttpGet("GetAllCricketDetails")]
        public async Task<List<Cricket>> GetAllCricketDetails()
        {
            /*int a = 0;
            int b = 10 / a;*/
            var command = new GetCricketListQuery();
            return await _mediator.Send(command);
        }

        [HttpGet("GetCricketDataById")]
        public async Task<Cricket> GetCricketDataById(int id)
        {
            if(id == 0)
            {
                throw new Exception("Id can not be zero.");
            }
            var command  = new GetCricketByIdQuery() { Id = id};
            return await _mediator.Send(command);
        }

        [HttpPost("InsertFootballData")]
        public async Task<IActionResult> InsertFootballDetails(Football football)
        {
            await _sportsService.InsertFootballData(football);
            return Ok(football);
        }

        [HttpPost("InsertHockeyData")]
        public async Task<IActionResult> InsertHockeyDetails(Hockey hockey)
        {
            await _sportsService.InsertHockeyData(hockey);
            return Ok(hockey);
        }

    }
}
