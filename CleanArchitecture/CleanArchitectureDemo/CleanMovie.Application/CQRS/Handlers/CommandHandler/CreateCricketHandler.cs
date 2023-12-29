using CleanMovie.Application.CQRS.Command;
using CleanMovie.Application.Interfaces.IServices;
using CleanMovie.Domain.EntityModels;
using MediatR;

namespace CleanMovie.Application.CQRS.Handlers.CommandHandler
{
    public class CreateCricketHandler : IRequestHandler<CreateCricketCommand, Cricket>
    {
        private readonly ISportsService _sportsService;

        public CreateCricketHandler(ISportsService sportsService)
        {
            _sportsService = sportsService;
        }
        public async Task<Cricket> Handle(CreateCricketCommand request, CancellationToken cancellationToken)
        {
            return await _sportsService.CreateCricketData(request.cricket);
        }
    }
}
