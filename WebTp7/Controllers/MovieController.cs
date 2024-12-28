
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTp7.Models;
using WebTp7.Services.ServiceContracts;

namespace WebTp7.Controllers;

[Authorize (Roles = "customer,admin")]

public class MovieController : Controller
{

    protected readonly IMovieService _movieServices;
    protected readonly IGenreServices _genreServices;
    protected readonly IFeedBackService _feedBackService;
    protected readonly IFavoriteService _favoriteService;

    public MovieController(IMovieService movieService , IGenreServices genreServices , IFeedBackService feedBackService , IFavoriteService favoriteService)
    {
        _movieServices = movieService;
        _genreServices = genreServices;
        _feedBackService = feedBackService;
        _favoriteService = favoriteService;
    }
    
    
    
    public IActionResult Index()
    {

        IEnumerable<Movie> movies = _movieServices.getMovies();
        ViewBag.state = "Yes";
        
        return View(movies);
    }

    
    
    [HttpGet]
    [Route("Movie/Index/{genreId}")]
    public IActionResult Index(int genreId)
    {
        IEnumerable<Movie> movies = _movieServices.getMoviesWithGenre(genreId);
        var genre = _genreServices.getGenre(genreId);
        ViewBag.CorrectName = genre.Name;
        return View(movies);
    }
    
    public IActionResult Details(int id)
    {
        var movie = _movieServices.getMovie(id);
        var feedBacks = _feedBackService.GetFeedBacks(id);
        
        var moviedetails = new MovieDetails
        {
            Movie = movie,
            FeedBacks = feedBacks.ToList()
        };
        
        return View(moviedetails);
    }
    public IActionResult getFavoriteMovies(String id)
    {
        var movies = _favoriteService.GetFavoriteMovies(id);
        
        return View("/Views/User/FavMovies.cshtml",movies);
    }
    
}