using MediatR;
using MovieManagement.Library.Commands;
using MovieManagement.Library.Repo;
using MovieManagement.Model.Models;

namespace MovieManagement.Library.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, MovieModel>
    {
        private readonly IDataRepository _dataRepository;

        public AddMovieHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public async Task<MovieModel> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            return await _dataRepository.AddMovie(request.model);
        }
    }
}
