using MediatR;
using MovieManagement.Library.Queries;
using MovieManagement.Library.Repo;
using MovieManagement.Model.Models;

namespace MovieManagement.Library.Handlers
{
    public class GetMovieListHandler : IRequestHandler<GetMovieListQuery, List<MovieModel>>
    {
        private readonly IDataRepository _dataRepository;
        public GetMovieListHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public async Task<List<MovieModel>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            return await _dataRepository.GetMovies();
        }
    }
}
