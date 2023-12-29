using CleanMovie.Domain.EntityModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.CQRS.Queries
{
    public class GetCricketByIdQuery : IRequest<Cricket>
    {
        public int Id { get; set; }
    }
}
