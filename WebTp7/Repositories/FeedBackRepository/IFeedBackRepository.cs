using WebTp7.Models;
using WebTp7.Repositories.GenericRepository;

namespace WebTp7.Repositories.FeedbackRepository;

public interface IFeedBackRepository : IGenericRepository<FeedBack>
{
    public IEnumerable<FeedBack> getFeedBacks(int MovieId);
    public void AddFeedBack(FeedBack feedBack);
    
    public void DeleteFeedBack(int feedBackId);
    
    
}