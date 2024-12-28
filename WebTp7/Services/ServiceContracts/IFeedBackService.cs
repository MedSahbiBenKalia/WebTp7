using WebTp7.Models;

namespace WebTp7.Services.ServiceContracts;

public interface IFeedBackService
{
    public void AddFeedBack(FeedBack feedBack);
    public IEnumerable<FeedBack> GetFeedBacks(int MovieId);
    
    public void DeleteFeedBack(int feedBackId);
    
    public FeedBack GetFeedBack(int feedBackId);
    
    public void UpdateFeedBack(FeedBack feedBack);

    public decimal getavgfeedback(int MovieId);
}