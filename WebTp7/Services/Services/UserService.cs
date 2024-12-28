using WebTp7.Models;
using WebTp7.Repositories.UserRepository;
using WebTp7.Services.ServiceContracts;

namespace WebTp7.Services.Services;

public class UserService : IUserService
{
    protected readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public List<ApplicationUser> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

}