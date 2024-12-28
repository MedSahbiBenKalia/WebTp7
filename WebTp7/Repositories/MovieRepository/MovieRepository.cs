using WebTp7.Data;
using WebTp7.Models;
using WebTp7.Repositories.GenericRepository;

namespace WebTp7.Repositories.MovieRepository;


public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(ApplicationDbContext context) : base(context)
    {
    }

    
    public IEnumerable<Movie> getMovies()
    {
        var movies = GetAll(m => m.Genre);
        
        return movies ;
    }
    
    public Movie getMovie(int movieid)
    {
        var moviesById = GetById(movieid , m => m.Genre , m => m.FavoriteByUsers);
        return moviesById;

    }
    

    public IEnumerable<Movie> getMoviesWithGenre(int genreId ) 
    {
        var movieByGenre = Find(m => m.GenreId == genreId , m => m.Genre);
        return movieByGenre;
    }

    public IEnumerable<Movie> getMoviesOrdered()
    {
        return GetAll(m => m.Genre).OrderBy(m => m.Name);
    }
    
}