using MediatR;
using MovieManagement.Library.Queries;
using MovieManagement.Library.Repo;
using MovieManagement.Model.Models;

namespace MovieManagement.Library.Handlers
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MovieModel>
    {
        private readonly IDataRepository _dataRepository;

        public GetMovieByIdHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public async Task<MovieModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dataRepository.GetMovieById(request.id);
        }

    }
}
