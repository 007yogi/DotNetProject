using CleanMovie.Domain.EntityModels;

namespace CleanMovie.Application.Interfaces.IServices
{
    public interface IMovieService
    {
        // add 'Id' property in interface for get the vlaue of 'AddScoped', 'AddScoped', 'AddTransient'.
        string Id { get; set; }

        List<Movie> GetAllMoviesFromService();
        Movie CreateMovieFromService(Movie movie);        
    }
}
