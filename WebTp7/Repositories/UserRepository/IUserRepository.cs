using WebTp7.Models;
using WebTp7.Repositories.GenericRepository;

namespace WebTp7.Repositories.UserRepository;

public interface IUserRepository : IGenericRepository<ApplicationUser>
{
    public ApplicationUser GetUserById(String id);
    public List<ApplicationUser> GetAllUsers();
    
    
}