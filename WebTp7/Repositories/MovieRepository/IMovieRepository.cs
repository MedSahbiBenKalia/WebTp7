

using System.Linq.Expressions;
using WebTp7.Models;
using WebTp7.Repositories.GenericRepository;

public interface IMovieRepository : IGenericRepository<Movie>
{
    IEnumerable<Movie> getMovies();
    
    Movie getMovie(int movieid );
  
    IEnumerable<Movie> getMoviesWithGenre(int genreId);
    IEnumerable<Movie> getMoviesOrdered();
}