
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTp7.Models;
using WebTp7.Services.ServiceContracts;

namespace WebTp7.Controllers;

[Authorize(Roles = "admin , customer")]
public class GenreController : Controller
{
    protected readonly IGenreServices _genreServices;
    protected readonly IMovieService _movieServices;
    public GenreController(IGenreServices genreServices , IMovieService movieServices)
    {
        _genreServices = genreServices;
        _movieServices = movieServices;
    }
    public IActionResult Index()
    {
        IEnumerable<Genre> genres = _genreServices.getGenres();
        
        return View(genres);
    }
    
    
    
    
    
}