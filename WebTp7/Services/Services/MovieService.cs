
using WebTp7.Models;

using WebTp7.Services.ServiceContracts;

namespace WebTp7.Services.Services;

public class MovieService : IMovieService
{
    protected readonly IMovieRepository _repository;
    
    public MovieService(IMovieRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<Movie> getMovies()
    {
        var movies = _repository.getMovies();
        return movies;
    }
    
    public Movie getMovie(int movieid)
    {
        var moviesById = _repository.getMovie(movieid);
        return moviesById;
    }
    public IEnumerable<Movie> getMovies(int genreId)
    {
        var MoviesSelectedByGenre = _repository.getMoviesWithGenre(genreId);
        return MoviesSelectedByGenre;
    }
    
    public IEnumerable<Movie> getMoviesWithGenre(int genreId)
    {
        var MoviesSelectedByGenre = _repository.getMoviesWithGenre(genreId);
        return MoviesSelectedByGenre;
    }

    public IEnumerable<Movie> getMoviesOrdered()
    {
        var movies = _repository.getMoviesOrdered();
        return movies;
    }
    public void UpdateRating(int movieId, decimal avgfeedback)
    {
        var movie = _repository.getMovie(movieId);
        movie.Rating = avgfeedback;
        _repository.Update(movie);
        _repository.Save();
    }
}