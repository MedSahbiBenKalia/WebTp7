using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTp7.Models;
using WebTp7.Services.ServiceContracts;


namespace WebTp7.Controllers;


[Authorize(Roles = "admin , customer")]
public class FeedbackController : Controller
{
    protected readonly IFeedBackService _feedBackService;
    protected readonly IMovieService _movieService;
    protected readonly IRatingService _ratingService;
    
    public FeedbackController(IFeedBackService feedBackService, IMovieService movieService , IRatingService ratingService)
    {
        _feedBackService = feedBackService;
        _movieService = movieService;
        _ratingService = ratingService;
    }
    
    
    [HttpGet]
    public IActionResult AddFeedback(int MovieId)
    {
        ViewBag.MovieId = MovieId; 
        ViewBag.UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        
        return View();
    }
    
    [HttpPost]
    public IActionResult AddFeedback(FeedBack feedback)
    {
        _feedBackService.AddFeedBack(feedback);
        
        _ratingService.UpdateRating(feedback.MovieId);
        
        return RedirectToAction("Details", "Movie", new { id = feedback.MovieId });
    }
    
    [HttpGet]
    public IActionResult deleteFeedback(int FeedbackId , int MovieId)
    {
        _feedBackService.DeleteFeedBack(FeedbackId);
        
        _ratingService.UpdateRating(MovieId);
        
        return RedirectToAction("Details", "Movie", new { id = MovieId});
    }
    
    [HttpGet]
    public IActionResult UpdateFeedback(int FeedbackId )
    {
        var feedback = _feedBackService.GetFeedBack(FeedbackId);
        
        
        return View(feedback);
    }
    
    
    [HttpPost]
    public IActionResult UpdateFeedback(FeedBack feedback)
    {
        _feedBackService.UpdateFeedBack(feedback);
        
        _ratingService.UpdateRating(feedback.MovieId);
        
        return RedirectToAction("Details", "Movie", new { id = feedback.MovieId });
    }
    
    
    
}