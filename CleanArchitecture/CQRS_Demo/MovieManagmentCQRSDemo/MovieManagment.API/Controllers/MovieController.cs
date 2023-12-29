using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Library.Commands;
using MovieManagement.Library.Queries;
using MovieManagement.Model.Models;

namespace MovieManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ISender _mediator;

        public MovieController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddMovie")]
        public async Task<MovieModel> AddMovie(MovieModel model)
        {
            var command = new AddMovieCommand(model);
            return await _mediator.Send(command);
        }
        [HttpGet("GetMovies")]
        public async Task<List<MovieModel>> GetMovies()
        {
            var command = new GetMovieListQuery();
            return await _mediator.Send(command);
        }
        [HttpGet("GetMovieById/{id}")]
        public async Task<MovieModel> GetMovieById(int id)
        {
            if(id == 0)
            {
                throw new Exception("id can not be 0.");
            }
            var command = new GetMovieByIdQuery(id);
            return await _mediator.Send(command);
        }
    }
}
