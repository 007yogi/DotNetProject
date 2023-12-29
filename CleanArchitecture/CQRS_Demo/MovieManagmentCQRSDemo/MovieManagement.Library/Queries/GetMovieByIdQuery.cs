using MediatR;
using MovieManagement.Model.Models;

namespace MovieManagement.Library.Queries
{
    public record GetMovieByIdQuery(int id) : IRequest<MovieModel>;
}
