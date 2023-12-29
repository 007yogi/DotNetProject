using CleanMovie.Application.Interfaces.IServices;
using CleanMovie.Domain.EntityModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        //private readonly ISportRepository _sportRepository;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        
        [HttpGet("GetAllMovies")]
        public ActionResult<List<Movie>> GetAllMovies()
        {
            //_sportRepository.GetCricket();

            var moviesFromService = _service.GetAllMoviesFromService();
            return Ok(moviesFromService);
        }

        [HttpPost("CreateMovie")]
        public ActionResult CreateMovie(Movie movie)
        {
            var result = _service.CreateMovieFromService(movie);
            return Ok(movie);
        }        
    }
}
