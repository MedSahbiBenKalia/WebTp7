
using WebTp7.Data;
using WebTp7.Models;
using WebTp7.Repositories.GenericRepository;


namespace WebTp7.Repositories.GenreRepository;

public class GenreRepository : GenericRepository<Genre> , IGenreRepository
{
    public GenreRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IEnumerable<Genre> getGenres()
    {
        return GetAll();
    }

    public Genre getGenre(int genreId)
    {
        return GetById(genreId);
    }
    
}