using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTp7.Services.ServiceContracts;

namespace WebTp7.Controllers;

[Authorize(Roles = "customer")]
public class UserController : Controller
{
    protected readonly IUserService _userService;
    protected readonly IFavoriteService _favoriteService;
    public UserController(IUserService userService, IFavoriteService favoriteService)
    {
        _userService = userService;
        _favoriteService = favoriteService;
    }
    [Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        var users = _userService.GetAllUsers();
        return View(users);
    }
    
    public IActionResult getFavoriteMovies(String id)
    {
        var movies = _favoriteService.GetFavoriteMovies(id);
        
        return View("FavMovies",movies);
    }
    
}