using WebTp7.Models;

namespace WebTp7.Services.ServiceContracts;

public interface IUserService
{
    public List<ApplicationUser> GetAllUsers();
    
}