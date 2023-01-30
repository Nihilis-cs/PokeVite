using System.Runtime.CompilerServices;
namespace server.services;
public interface IUserServices
{
    
}
public class UserServices : IUserServices
{
    private readonly PokeDbContext _dbContext;
    public UserServices(PokeDbContext aDbContext)
    {
        _dbContext = aDbContext;
    }


}