using MediatR;
using MovieManagement.Model.Models;

namespace MovieManagement.Library.Commands
{
    public record AddMovieCommand(MovieModel model) : IRequest<MovieModel>;
}
