using Microsoft.AspNetCore.Identity;
namespace WebTp7.Models;
public class ApplicationUser : IdentityUser
{
    public List<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();
    public List<Movie> FavoriteMovies { get; set; } = new List<Movie>();
}
