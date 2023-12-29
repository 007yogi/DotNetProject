using CleanMovie.Application.CQRS.Queries;
using CleanMovie.Application.Interfaces.IServices;
using CleanMovie.Domain.EntityModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.CQRS.Handlers.QueryHandler
{
    public class GetCricketByIdHandler : IRequestHandler<GetCricketByIdQuery, Cricket>
    {
        private readonly ISportsService _sportsService;
        public GetCricketByIdHandler(ISportsService sportsService)
        {
            _sportsService = sportsService;
        }       

        public async Task<Cricket> Handle(GetCricketByIdQuery request, CancellationToken cancellationToken)
        {
            return await _sportsService.GetCricketDataById(request.Id);
        }
    }
}
