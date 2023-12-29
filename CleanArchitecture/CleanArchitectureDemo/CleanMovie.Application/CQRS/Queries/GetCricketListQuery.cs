using CleanMovie.Domain.EntityModels;
using MediatR;

namespace CleanMovie.Application.CQRS.Queries
{
    public record GetCricketListQuery() : IRequest<List<Cricket>>;
    
}
