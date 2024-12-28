using WebTp7.Data;
using WebTp7.Models;
using WebTp7.Repositories.GenericRepository;

namespace WebTp7.Repositories.FeedbackRepository;

public class FeedBackRepository : GenericRepository <FeedBack> , IFeedBackRepository
{
    public FeedBackRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IEnumerable<FeedBack> getFeedBacks(int MovieId)
    {
        return Find(f => f.MovieId == MovieId , f => f.User);
    }
    

 
    public void AddFeedBack(FeedBack feedBack)
    {
        Console.WriteLine($"Feedback added: {feedBack.Comment}, Rating: {feedBack.Rating}, UserId: {feedBack.UserId}, MovieId: {feedBack.MovieId}");
        Insert(feedBack);
        Save();
    }
    
    public void DeleteFeedBack(int feedBackId)
    {
        Delete(feedBackId);
        Save();
    }
}
