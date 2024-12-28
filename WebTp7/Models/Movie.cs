using System.ComponentModel.DataAnnotations.Schema;

namespace WebTp7.Models;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Rating { get; set; } = 0;
    
    public List<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();
    
    public List<ApplicationUser> FavoriteByUsers { get; set; } = new List<ApplicationUser>();
    
    
}