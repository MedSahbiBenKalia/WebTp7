using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Identity;

namespace WebTp7.Models;

public class FeedBack
{
    public int Id { get; set; }
    
    public String? Comment { get; set; }
    
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int? Rating { get; set; }
    
    public String UserId { get; set; }
    public ApplicationUser User { get; set; }
    
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    
    
}