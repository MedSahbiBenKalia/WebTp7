using WebTp7.Services.ServiceContracts;

namespace WebTp7.Services.Services;

public class RatingService : IRatingService
{
    protected readonly IMovieService _movieService;
    protected readonly IFeedBackService _feedBackService;
    
    public RatingService(IMovieService movieService, IFeedBackService feedBackService)
    {
        _movieService = movieService;
        _feedBackService = feedBackService;
    }
    
    public void UpdateRating(int movieId)
    {
        decimal avgfeedback=_feedBackService.getavgfeedback(movieId);
        _movieService.UpdateRating(movieId, avgfeedback);
    }
    
}