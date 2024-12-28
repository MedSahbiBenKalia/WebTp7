
using WebTp7.Models;

namespace WebTp7.Services.ServiceContracts;

public interface IMovieService
{
    IEnumerable<Movie> getMovies();
    
    Movie getMovie(int MovieId );
    IEnumerable<Movie> getMovies(int genreId);

    public IEnumerable<Movie> getMoviesWithGenre(int genreId);
    IEnumerable<Movie> getMoviesOrdered();
    
    void UpdateRating(int movieId, decimal avgfeedback);
}