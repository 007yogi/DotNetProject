using MediatR;
using MovieManagement.Model.Models;

namespace MovieManagement.Library.Queries
{
    public record GetMovieListQuery() : IRequest<List<MovieModel>>;
}
