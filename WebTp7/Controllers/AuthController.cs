using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebTp7.JWTBearerConfig;
using WebTp7.Models;



namespace WebTp7.Controllers
{
    public class AuthController : Controller
    {
        private readonly JWTBearerTokenSettings jwtBearerTokenSettings;
        private readonly UserManager<ApplicationUser> userManager;
        public SignInManager<ApplicationUser> signInManager { get; set; }

        public AuthController(IOptions<JWTBearerTokenSettings> jwtTokenOptions, UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.jwtBearerTokenSettings = jwtTokenOptions.Value;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register( RegisterCredentials userDetails)
        {
            if (!ModelState.IsValid || userDetails == null)
            {
                ViewBag.errorMessage = "User Registration Failed (Username should not be empty)";
                return View();
            }

            var ApplicationUser = new ApplicationUser()
            {
                UserName = userDetails.username,
                Email = userDetails.Email
            };

            var result = await userManager.CreateAsync(ApplicationUser, userDetails.Password);
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }
                //return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
                ViewBag.LoginError =new{ name= "User Registration Failed",Errors = dictionary};
                return View();
            }
            //assign role to user after registration as customer
            await userManager.AddToRoleAsync(ApplicationUser, "customer");
            ViewBag.Message = "User Registration Successful press login to continue";
            return View();
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }        
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login( LoginCredentials credentials)
        {
            ApplicationUser ApplicationUser;

            if (!ModelState.IsValid || credentials == null || (ApplicationUser = await ValidateUser(credentials)) == null)
            {
                ViewBag.errorMessage = "Login failed";
                return View();
            }

            var token = await GenerateToken(ApplicationUser);
            HttpContext.Session.SetString("BearerToken", token);
            
            //check if the tokken is storred
            /*
            var sessionData = new Dictionary<string, string>();
            foreach (var key in HttpContext.Session.Keys)
            {
                sessionData[key] = HttpContext.Session.GetString(key);
            }
            return Json(new { sessionData });
            */ 
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            // Well, What do you want to do here ?
            // Wait for token to get expired OR
            // Maintain token cache and invalidate the tokens after logout method
            HttpContext.Session.Remove("BearerToken");
            return RedirectToAction("Index", "Home");
        }

        private async Task<ApplicationUser> ValidateUser(LoginCredentials credentials)
        {
            var ApplicationUser = await userManager.FindByNameAsync(credentials.Username);
            if (ApplicationUser != null)
            {
                var result = userManager.PasswordHasher.VerifyHashedPassword(ApplicationUser, ApplicationUser.PasswordHash, credentials.Password);
                return result == PasswordVerificationResult.Failed ? null : ApplicationUser;
            }
            return null;
        }

        private async Task<String> GenerateToken(ApplicationUser ApplicationUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);
            
            var roles = await userManager.GetRolesAsync(ApplicationUser);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, ApplicationUser.UserName),
                new Claim(ClaimTypes.Email, ApplicationUser.Email),
                new Claim(ClaimTypes.NameIdentifier, ApplicationUser.Id), // Add NameIdentifier to get the user for the ClaimsPrincipal
            };

            // Add each role as a separate claim
            //claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(jwtBearerTokenSettings.ExpireTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = jwtBearerTokenSettings.Audience,
                Issuer = jwtBearerTokenSettings.Issuer
            };

            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        
        
    }
}