using WebTp7.Data;
using WebTp7.Models;
using WebTp7.Repositories.GenericRepository;
namespace WebTp7.Repositories.UserRepository;

public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ApplicationUser GetUserById(String id)
    {
        return GetById(id, u => u.FavoriteMovies);
    }

    public List<ApplicationUser> GetAllUsers()
    {
        return GetAll().ToList();
    }
    
}