using WebTp7.Models;
using WebTp7.Repositories.UserRepository;
using WebTp7.Services.ServiceContracts;

namespace WebTp7.Services.Services;

public class FavoriteServivce : IFavoriteService
{
    
    protected readonly IUserRepository _userRepository;
    protected readonly IMovieService _movieService;

    public FavoriteServivce(IUserRepository userRepository, IMovieService movieService)
    {
        _userRepository = userRepository;
        _movieService = movieService;
    }

    public void AddToFavorite(String UserId, int MovieId)
    {
        var movie = _movieService.getMovie(MovieId);
        var user = _userRepository.GetUserById(UserId);
   
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        // Check if the movie is already in the user's favorites
        if (user.FavoriteMovies.Any(m => m.Id == MovieId))
        {
            throw new Exception("Movie is already in the user's favorites.");
        }

        // Add the movie to the user's favorite movies
        user.FavoriteMovies.Add(movie);

        // Save changes to the database
        _userRepository.Save();
        

    }
    
    public void RemoveFromFavorite(String UserId, int MovieId)
    {
        var movie = _movieService.getMovie(MovieId);
        var user = _userRepository.GetUserById(UserId);
        
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        // Check if the movie is in the user's favorites
        if (!user.FavoriteMovies.Any(m => m.Id == MovieId))
        {
            throw new Exception("Movie is not in the user's favorites.");
        }

        // Remove the movie from the user's favorite movies
        user.FavoriteMovies.Remove(movie);

        // Save changes to the database
        _userRepository.Save();
    }
    
    public List<Movie> GetFavoriteMovies(String UserId)
    {
        var user = _userRepository.GetUserById(UserId);
        
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        return user.FavoriteMovies;
    }



}