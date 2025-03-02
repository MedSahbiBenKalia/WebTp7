using System.ComponentModel.DataAnnotations;

namespace WebTp7.Models;

public class LoginCredentials
{
    [Required]
    [StringLength(256, ErrorMessage = "Username must not exceed 256 characters.")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, ErrorMessage = "Password must be at least {2} and at most {1} characters long.", MinimumLength = 6)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[\W_])(?=.*\d).+$", 
        ErrorMessage = "Password must contain at least one uppercase letter, one symbol, and one digit.")]
    public string Password { get; set; }
}