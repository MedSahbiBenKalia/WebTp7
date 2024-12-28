using WebTp7.Models;

using WebTp7.Repositories.GenreRepository;
using WebTp7.Services.ServiceContracts;

namespace WebTp7.Services.Services;

public class GenreService : IGenreServices
{
    protected readonly IGenreRepository _repository;
    
    public GenreService(IGenreRepository repository)
    {
        _repository = repository;
    }
    
    
    public IEnumerable<Genre> getGenres()
    {
        var genres = _repository.getGenres();
        return genres;
    }
    
    public Genre getGenre(int genreId)
    {
        var genre = _repository.getGenre(genreId);
        return genre;
    }
    
}