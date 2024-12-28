


using WebTp7.Models;
using WebTp7.Repositories.GenericRepository;

namespace WebTp7.Repositories.GenreRepository;

public interface IGenreRepository : IGenericRepository<Genre>
{
    IEnumerable<Genre> getGenres();
    Genre getGenre(int genreId);
    
}