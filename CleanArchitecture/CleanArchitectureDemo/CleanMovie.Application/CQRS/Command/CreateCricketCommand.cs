using CleanMovie.Domain.EntityModels;
using MediatR;

namespace CleanMovie.Application.CQRS.Command
{
    public record CreateCricketCommand(Cricket cricket) : IRequest<Cricket>;   
    
}
