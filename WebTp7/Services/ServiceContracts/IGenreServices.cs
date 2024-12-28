using WebTp7.Models;

namespace WebTp7.Services.ServiceContracts;

public interface IGenreServices
{
    IEnumerable<Genre> getGenres();
    Genre getGenre(int genreId);
}