using CleanMovie.Application.CQRS.Queries;
using CleanMovie.Application.Interfaces.IServices;
using CleanMovie.Domain.EntityModels;
using MediatR;

namespace CleanMovie.Application.CQRS.Handlers.QueryHandler
{
    public class GetCricketListHandler : IRequestHandler<GetCricketListQuery, List<Cricket>>
    {
        private readonly ISportsService _sportsService;

        public GetCricketListHandler(ISportsService sportsService)
        {
            _sportsService = sportsService;
        }
        public async Task<List<Cricket>> Handle(GetCricketListQuery request, CancellationToken cancellationToken)
        {
            return await _sportsService.GetCricketData();
        }
    }
}
