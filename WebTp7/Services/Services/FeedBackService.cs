using WebTp7.Models;
using WebTp7.Repositories.FeedbackRepository;
using WebTp7.Services.ServiceContracts;

namespace WebTp7.Services.Services;

public class FeedBackService : IFeedBackService
{
    protected readonly IFeedBackRepository _repository;

    public FeedBackService(IFeedBackRepository repository)
    {
        _repository = repository;
    }

    public void AddFeedBack(FeedBack feedBack)
    {
        _repository.AddFeedBack(feedBack);
    }
    public IEnumerable<FeedBack> GetFeedBacks(int MovieId)
    {
        return _repository.getFeedBacks(MovieId);
    }
    
    public void DeleteFeedBack(int feedBackId)
    {
        _repository.DeleteFeedBack(feedBackId);
    }
    
    public FeedBack GetFeedBack(int feedBackId)
    {
        return _repository.GetById(feedBackId);
    }
    
    public void UpdateFeedBack(FeedBack feedBack)
    {
        _repository.Update(feedBack);
        _repository.Save();
        
    }
    
    public decimal getavgfeedback(int MovieId)
    {
        var feedbacks = _repository.getFeedBacks(MovieId);
    
        if (feedbacks == null || !feedbacks.Any())
        {
            return 0; 
        }
        return (decimal) feedbacks.Average(f => f.Rating);
    }
    
}