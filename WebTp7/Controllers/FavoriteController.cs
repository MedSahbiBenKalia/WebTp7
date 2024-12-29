using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTp7.Services.ServiceContracts;
using WebTp7.Services.Services;

namespace WebTp7.Controllers;

[Authorize (Roles = "customer,admin")]
public class FavoriteController : Controller
{
    protected readonly IFavoriteService _favoriteService;
    public FavoriteController(IFavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }
    
    public IActionResult AddToFavorite(String UserId, int MovieId)
    {
        try
        {
            _favoriteService.AddToFavorite(UserId, MovieId);
            return RedirectToAction("Details", "Movie", new { id = MovieId });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    public IActionResult RemoveFromFavorite(String UserId, int MovieId)
    {
        try
        {
            _favoriteService.RemoveFromFavorite(UserId, MovieId);
            return RedirectToAction("Details", "Movie", new { id = MovieId });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}