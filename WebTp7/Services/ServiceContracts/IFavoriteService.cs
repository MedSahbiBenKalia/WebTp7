using WebTp7.Models;

namespace WebTp7.Services.ServiceContracts;

public interface IFavoriteService
{
    public void AddToFavorite(String UserId, int MovieId);
    public void RemoveFromFavorite(String UserId, int MovieId);
    
    public List<Movie> GetFavoriteMovies(String UserId);
}